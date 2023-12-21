using System;

public interface IApplicationStateManager
{
    event EventHandler<ApplicationStateChangedArgs> ApplicationStateChanged;
    ApplicationStateType CurrentApplicationStateType { get; }
    void SetState(ApplicationStateType newStateType);
}