using Straumann.Core;
using Straumann.UI;

namespace StateHandling.Handlers
{
    public class Case3dState : IApplicationState
    {
        // Dependencies
        private readonly IViewValidator m_ViewValidator;
        
        // Properties
        public ApplicationStateType ApplicationStateType => ApplicationStateType.Case3d;

        // Constructors
        public Case3dState(IViewValidator viewValidator)
        {
            m_ViewValidator = viewValidator;
        }

        // Methods
        public void Enter()
        {
            m_ViewValidator.UpdateViews(new [] { ViewType.Cases, ViewType.Case2d});
        }

        public void Exit()
        {
        }
    }
}