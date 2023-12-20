using System;

public interface IApplicationStateManager
{
    event EventHandler<ApplicationStateChangedArgs> ApplicationStateChanged;
    ApplicationState CurrentApplicationState { get; }
    void SetState(ApplicationState newState);
}