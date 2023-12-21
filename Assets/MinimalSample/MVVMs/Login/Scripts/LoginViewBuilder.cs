using System;
using Straumann.UI;
using UnityEngine.UIElements;
using VContainer;

namespace MVVMs.Login.Scripts
{
    public class LoginViewBuilder : IViewBuilder
    {
        // Dependencies
        private readonly IObjectResolver m_ObjectResolver;

        // Members
        private LoginViewModel m_LoginViewModel;

        // Properties
        public ViewType TargetType => ViewType.Login;

        // Constructors
        public LoginViewBuilder(IObjectResolver objectResolver)
        {
            m_ObjectResolver = objectResolver;
        }

        // Methods
        public void Build(UIDocument uiDocument)
        {
            if (m_LoginViewModel == null)
            {
                m_LoginViewModel = m_ObjectResolver.Resolve<LoginViewModel>();
            }
            
            uiDocument.rootVisualElement.dataSource = m_LoginViewModel;
        }
    }
}