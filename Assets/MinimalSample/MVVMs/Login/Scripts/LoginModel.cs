using UnityEngine;

public class LoginModel
{
    // Dependencies
    private readonly IUserService m_UserService;
    private readonly IApplicationStateManager m_ApplicationStateManager;

    // Events
    public event LoginModelUpdated LoginModelUpdated;

    // Properties
    public string UserName
    {
        get => m_UserName;
        set
        {
            m_UserName = value;
            Debug.Log($"[{this}] UserName updated: {m_UserName}");
            LoginModelUpdated?.Invoke(new(m_UserName, m_Password));
        }
    }

    public string Password
    {
        get => m_Password;
        set
        {
            m_Password = value;
            Debug.Log($"[{this}] Password updated: {m_Password}");
            LoginModelUpdated?.Invoke(new(m_UserName, m_Password));
        }
    }

    // Members
    private string m_UserName;
    private string m_Password;
    
    // Constructors
    public LoginModel(IUserService userService, IApplicationStateManager applicationStateManager)
    {
        Debug.Log($"[{this}] Constructor called!");

        m_UserService = userService;
        m_ApplicationStateManager = applicationStateManager;
        if (m_UserService.IsLoggedIn)
        {
            this.UserName = m_UserService.LoggedInUser;
        }
    }
    
    // Methods
    public async Awaitable<bool> TryLogIn(string userName)
    {
        var logIn = await m_UserService.LogIn(userName, m_Password);
        if (logIn)
        {
            m_ApplicationStateManager.SetState(ApplicationStateType.Home);
        }
        return logIn;
    }
}
