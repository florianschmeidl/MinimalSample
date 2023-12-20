using System;

public class ApplicationStateManager : IApplicationStateManager
{
    // Events
    public event EventHandler<ApplicationStateChangedArgs> ApplicationStateChanged; 
    
    // Properties
    public ApplicationState CurrentApplicationState { get; private set; } = ApplicationState.Initialize;

    // Methods
    public void SetState(ApplicationState newState)
    {
        var applicationStateChangedArgs = new ApplicationStateChangedArgs(CurrentApplicationState, newState);
        CurrentApplicationState = newState;
        ApplicationStateChanged?.Invoke(this, applicationStateChangedArgs);
    }
}
