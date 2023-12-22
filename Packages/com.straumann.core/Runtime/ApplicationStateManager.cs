using System;
using System.Collections.Generic;
using Straumann.Core;
using UnityEngine;


// TODO: Rename this e.g. ApplicationStateManagerAggregation?
public class Aggregate
{
    private readonly IApplicationStateManager m_applicationStateManager;
    private readonly StateSetter m_stateSetter;

    public Aggregate(IApplicationStateManager applicationStateManager, StateSetter stateSetter)
    {
        m_applicationStateManager = applicationStateManager;
        m_stateSetter = stateSetter;
        stateSetter.ApplicationStateChanged += applicationStateManager.SetState;
        Debug.Log("Construct Aggregate");
        stateSetter.SetState(ApplicationStateType.Login);
    }
}

// TODO: Rename this e.g. ApplicationStateManager?
public class StateSetter
{
    public StateSetter() { }

    public event Action<ApplicationStateType> ApplicationStateChanged;
    public void SetState(ApplicationStateType newStateType) 
    { 
        Debug.Log("Set state");
        ApplicationStateChanged?.Invoke(newStateType); 
    }
}

// TODO: Rename this e.g. ApplicationStateExecutor?
public class ApplicationStateManager : IApplicationStateManager
{
    // Dependencies
    private readonly IReadOnlyList<IApplicationState> m_ApplicationStates;

    // Events
    public event EventHandler<ApplicationStateChangedArgs> ApplicationStateChanged; 
    
    // Properties
    public ApplicationStateType CurrentApplicationStateType => m_CurrentApplicationState?.ApplicationStateType ?? ApplicationStateType.Unknown;
    
    // Members
    private IApplicationState m_CurrentApplicationState;

    // Constructors
    public ApplicationStateManager(IReadOnlyList<IApplicationState> applicationStates)
    {
        m_ApplicationStates = applicationStates;
        //SetState(ApplicationStateType.Initialize);
    }

    // Methods
    public void SetState(ApplicationStateType newStateType)
    {
        var previousApplicationState = CurrentApplicationStateType;
        IApplicationState nextApplicationState = null; 
        
        foreach (var applicationState in m_ApplicationStates)
        {
            if (applicationState.ApplicationStateType == newStateType)
            {
                nextApplicationState = applicationState;
                break;
            }
        }
        
        if (m_CurrentApplicationState != null)
        {
            m_CurrentApplicationState.Exit();
        }

        if (nextApplicationState != null)
        {
            m_CurrentApplicationState = nextApplicationState;
            m_CurrentApplicationState.Enter();
        }
        else
        {
            Debug.LogError($"No valid IApplicationState was found for {newStateType}.");
        }
        
        var applicationStateChangedArgs = new ApplicationStateChangedArgs(previousApplicationState, newStateType);
        ApplicationStateChanged?.Invoke(this, applicationStateChangedArgs);
    }
}