using Straumann.UI;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace MVVMs.Home.Scripts
{
    public class CasesViewBuilder : IViewBuilder
    {
        // Dependencies
        private readonly IObjectResolver m_ObjectResolver;

        // Members
        private CasesViewModel m_CasesViewModel;
        
        // Properties
        public ViewType TargetType => ViewType.Cases;
        
        // Constructors
        public CasesViewBuilder(IObjectResolver objectResolver)
        {
            m_ObjectResolver = objectResolver;
        }
        
        // Methods
        public void Build(UIDocument uiDocument)
        {
            if (m_CasesViewModel == null)
            {
                m_CasesViewModel = m_ObjectResolver.Resolve<CasesViewModel>();
            }
            
            uiDocument.rootVisualElement.dataSource = m_CasesViewModel;
        }
    }
}