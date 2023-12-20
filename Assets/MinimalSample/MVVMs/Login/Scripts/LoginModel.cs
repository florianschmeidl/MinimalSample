using UnityEngine;

public class LoginModel
{
    // Dependencies
    private readonly IUserService m_UserService;
    
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
            Debug.Log($"[{this}] UserName updated: {m_Password}");
            LoginModelUpdated?.Invoke(new(m_UserName, m_Password));
        }
    }

    // Members
    private string m_UserName;
    private string m_Password;
    
    // Constructors
    public LoginModel(IUserService userService)
    {
        Debug.Log($"[{this}] Constructor called!");

        m_UserService = userService;
        if (m_UserService.IsLoggedIn)
        {
            this.UserName = m_UserService.LoggedInUser;
        }
    }
    
    // Methods
    public async Awaitable<bool> TryLogIn()
    {
        return await m_UserService.LogIn(m_UserName, m_Password);
    }
}
