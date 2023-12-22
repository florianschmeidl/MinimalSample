using Straumann.UI;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace MVVMs.Home.Scripts
{
    public class Case2dViewBuilder : IViewBuilder
    {
        // Dependencies
        private readonly IObjectResolver m_ObjectResolver;

        // Members
        private Case2dViewModel m_Case2dViewModel;
        
        // Properties
        public ViewType TargetType => ViewType.Case2d;
        
        // Constructors
        public Case2dViewBuilder(IObjectResolver objectResolver)
        {
            m_ObjectResolver = objectResolver;
        }
        
        // Methods
        public void Build(UIDocument uiDocument)
        {
            if (m_Case2dViewModel == null)
            {
                m_Case2dViewModel = m_ObjectResolver.Resolve<Case2dViewModel>();
            }
            
            uiDocument.rootVisualElement.dataSource = m_Case2dViewModel;
            m_Case2dViewModel.Setup();
        }
    }
}