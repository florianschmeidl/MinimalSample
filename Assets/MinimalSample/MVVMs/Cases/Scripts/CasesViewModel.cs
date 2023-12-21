using System;
using System.Linq;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

public class CasesViewModel
{
    // Dependencies
    private readonly ApplicationStateManager m_ApplicationStateManager;
    
    // Properties
    [CreateProperty]
    public Action BackButtonClicked => HandleBackButton;
    [CreateProperty]
    public Action OpenCase1ButtonClicked =>HandleOpenCase1Button;
    [CreateProperty]
    public Action CloseCase1ButtonClicked =>  HandleCloseCase1Button;
    [CreateProperty]
    public Action OpenCase2ButtonClicked => HandleOpenCase2Button;
    [CreateProperty]
    public Action CloseCase2ButtonClicked => HandleCloseCase2Button;
    
    // Constructors
    public CasesViewModel(ApplicationStateManager applicationStateManager)
    {
        m_ApplicationStateManager = applicationStateManager;
    }
    
    // Methods
    private void HandleBackButton()
    {
        Debug.Log("Back");
        m_ApplicationStateManager.SetState(ApplicationStateType.Home);
    }

    private void HandleCloseCase1Button()
    {
        Debug.Log("Close Case 1");
        m_ApplicationStateManager.SetState(ApplicationStateType.Cases);
    }

    private void HandleOpenCase1Button()
    {
        Debug.Log("Open Case 1");
        m_ApplicationStateManager.SetState(ApplicationStateType.Case3d);
    }

    private void HandleCloseCase2Button()
    {
        Debug.Log("Close Case 2");
        m_ApplicationStateManager.SetState(ApplicationStateType.Cases);
    }

    private void HandleOpenCase2Button()
    {
        Debug.Log("Open Case 2");
        m_ApplicationStateManager.SetState(ApplicationStateType.Case3d);
    }
}