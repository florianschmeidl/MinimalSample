using System;
using UnityEngine;

public class LoginModel
{
    // Dependencies
    private readonly IUserService m_UserService;
    
    // Events
    public event EventHandler Changed;

    // Properties
    public string UserName
    {
        get => m_UserName;
        set
        {
            m_UserName = value;
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }
    public string Password
    {
        get => m_Password;
        set
        {
            m_Password = value;
            Changed?.Invoke(this, EventArgs.Empty);
        }
    }

    // Members
    private string m_UserName;
    private string m_Password;
    
    // Constructors
    public LoginModel(IUserService userService)
    {
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
