using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UIElements;

namespace Straumann.UI
{
    public class UIFactory : IUIFactory
    {
        // Dependencies
        private readonly IVisualTreeProvider m_VisualTreeProvider;
        private readonly IViewFactory m_ViewFactory;
        private readonly IReadOnlyList<IViewBuilder> m_VisualBuilders;

        // Constructors
        public UIFactory(IVisualTreeProvider visualTreeProvider, IViewFactory viewFactory, IReadOnlyList<IViewBuilder> visualBuilders)
        {
            m_VisualTreeProvider = visualTreeProvider;
            m_ViewFactory = viewFactory;
            m_VisualBuilders = visualBuilders;
        }

        public async Awaitable<UIDocument> Make(ViewType viewType)
        {
            var visualTreeAsset = await m_VisualTreeProvider.GetAsync(viewType);
            var uiDocument = m_ViewFactory.Make(viewType, visualTreeAsset);

            foreach (var visualBuilder in m_VisualBuilders)
            {
                if (visualBuilder.TargetType == viewType)
                {
                    visualBuilder.Build(uiDocument);
                    break;
                }
            }
            return uiDocument;
        }
    }
}