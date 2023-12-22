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

        // Members
        private StateDescription m_Description = new(new[] { ViewType.Login }) ;

        // Constructors
        public LoginState(IViewValidator viewValidator)
        {
            m_ViewValidator = viewValidator;
        }

        // Methods
        public void Enter()
        {
            // TODO: I don't like it too much, that the enter method of the state is
            // responsible for the clean up of the previous state
            // --> I would prefer to have a "Destroy(StateDescription stateDescription)" and "CreateStateViews" method
            m_ViewValidator.UpdateViews(new [] { ViewType.Login, ViewType.Login });
            
            // TODO: Integrate this behaviour
            // Create GameObject
            // Play Open Animation
            // Wait for all Views to complete OpenAnimation 
            // Unblock all Views
        }

        public void Exit()
        {
            // TODO: Integrate this behaviour
            // Set all states blocked
            // Play Close Animation
            // Destroy GameObject from Enter
        }
    }
}

// TODO: Review this Type
public readonly struct StateDescription
{
    public ViewType[] MendatoryViewTypes { get; }
    public ViewType[] OptionalViewTypes { get; }

    public StateDescription(ViewType[] mendatoryViewTypes, params ViewType[] optionalViewTypes)
    {
        MendatoryViewTypes = mendatoryViewTypes;
        OptionalViewTypes = optionalViewTypes;
    }
}