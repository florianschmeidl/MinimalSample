using Straumann.Core;
using Straumann.UI;

namespace StateHandling.Handlers
{
    public class CasesState : IApplicationState
    {
        // Dependencies
        private readonly IViewValidator m_ViewValidator;
        
        // Properties
        public ApplicationStateType ApplicationStateType => ApplicationStateType.Cases;

        // Constructors
        public CasesState(IViewValidator viewValidator)
        {
            m_ViewValidator = viewValidator;
        }

        // Methods
        public void Enter()
        {
            m_ViewValidator.UpdateViews(new [] { ViewType.Cases });
        }

        public void Exit()
        {
        }
    }
}