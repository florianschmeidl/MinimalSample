using System;
using Straumann.UI;
using UnityEngine.UIElements;
using VContainer;

namespace MVVMs.Login.Scripts
{
    public class LoginViewBuilder : IViewBuilder
    {
        // Dependencies
        private LoginViewModel m_LoginViewModel;

        // Properties
        public ViewType TargetType => ViewType.Login;

        // Constructors
        public LoginViewBuilder(LoginViewModel loginViewModel)
        {
            m_LoginViewModel = loginViewModel;
        }

        // Methods
        public void Build(UIDocument uiDocument)
        {            
            uiDocument.rootVisualElement.dataSource = m_LoginViewModel;
        }
    }
}