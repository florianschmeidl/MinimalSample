using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

public class HomeViewModel
{
    // Dependencies
    private readonly IUserService m_UserService;
    private readonly IApplicationStateManager m_ApplicationStateManager;

    // Properties
    [CreateProperty]
    public string HelloLabel { get; set; }
    
    [CreateProperty]
    public DisplayStyle LoadingVisibility { get; set; } = DisplayStyle.None;

    [CreateProperty]
    public Action LogoutButtonClicked => HandleLogOutButtonClicked;
    
    [CreateProperty]
    public Action CasesButtonClicked => HandleCasesButtonClicked;
    
    // Constructors
    public HomeViewModel(IUserService userService, IApplicationStateManager applicationStateManager)
    {
        m_UserService = userService;
        m_ApplicationStateManager = applicationStateManager;

        var userName = m_UserService.LoggedInUser;
        HelloLabel = $"hello {userName}";
    }

    private async void HandleLogOutButtonClicked()
    {
        LoadingVisibility = DisplayStyle.Flex;

        Debug.Log("Logout");
        await m_UserService.LogOut();
        m_ApplicationStateManager.SetState(ApplicationStateType.Login);
        LoadingVisibility = DisplayStyle.None;
        // todo discuss state after delete
    }

    private void HandleCasesButtonClicked()
    {
        LoadingVisibility = DisplayStyle.Flex;
        
        Debug.Log("Cases");
        m_ApplicationStateManager.SetState(ApplicationStateType.Cases);
        LoadingVisibility = DisplayStyle.None;
    }
}