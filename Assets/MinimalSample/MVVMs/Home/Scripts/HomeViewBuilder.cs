﻿using Straumann.UI;
using UnityEngine.UIElements;
using VContainer;

namespace MVVMs.Home.Scripts
{
    public class HomeViewBuilder : IViewBuilder
    {
        // Dependencies
        private readonly IObjectResolver m_ObjectResolver;

        // Members
        private HomeViewModel m_HomeViewModel;
        
        // Properties
        public ViewType TargetType => ViewType.Home;
        
        // Constructors
        public HomeViewBuilder(IObjectResolver objectResolver)
        {
            m_ObjectResolver = objectResolver;
        }
        
        // Methods
        public void Build(UIDocument uiDocument)
        {
            if (m_HomeViewModel == null)
            {
                m_HomeViewModel = m_ObjectResolver.Resolve<HomeViewModel>();
            }
            
            uiDocument.rootVisualElement.dataSource = m_HomeViewModel;
        }
    }
}