using Straumann.Core;
using Straumann.UI;

namespace StateHandling.Handlers
{
    public class LoginState : IApplicationState
    {
        // Dependencies
        private readonly IViewValidator m_ViewValidator;
        
        // Properties
        public ApplicationStateType ApplicationStateType => ApplicationStateType.Login;

        // Constructors
        public LoginState(IViewValidator viewValidator)
        {
            m_ViewValidator = viewValidator;
        }

        // Methods
        public void Enter()
        {
            m_ViewValidator.UpdateViews(new [] { ViewType.Login });
            
            // Create GameObject
        }

        public void Exit()
        {
            // Destroy GameObject from Enter
        }
    }
}