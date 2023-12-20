using System;

public class ApplicationStateChangedArgs : EventArgs
{
    // Properties
    public ApplicationState PreviousState { get; }
    public ApplicationState NewState { get; }

    // Constructors
    public ApplicationStateChangedArgs(ApplicationState previousState, ApplicationState newState)
    {
        PreviousState = previousState;
        NewState = newState;
    }
}
