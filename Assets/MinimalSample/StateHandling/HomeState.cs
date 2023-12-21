using Straumann.Core;
using Straumann.UI;

namespace StateHandling.Handlers
{
    public class HomeState : IApplicationState
    {
        // Dependencies
        private readonly IViewValidator m_ViewValidator;
        
        // Properties
        public ApplicationStateType ApplicationStateType => ApplicationStateType.Home;

        // Constructors
        public HomeState(IViewValidator viewValidator)
        {
            m_ViewValidator = viewValidator;
        }

        // Methods
        public void Enter()
        {
            m_ViewValidator.UpdateViews(new [] { ViewType.Home });
        }

        public void Exit()
        {
        }
    }
}