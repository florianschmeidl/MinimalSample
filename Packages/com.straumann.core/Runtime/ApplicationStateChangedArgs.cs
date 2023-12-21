using System;

public class ApplicationStateChangedArgs : EventArgs
{
    // Properties
    public ApplicationStateType PreviousStateType { get; }
    public ApplicationStateType NewStateType { get; }

    // Constructors
    public ApplicationStateChangedArgs(ApplicationStateType previousStateType, ApplicationStateType newStateType)
    {
        PreviousStateType = previousStateType;
        NewStateType = newStateType;
    }
}
