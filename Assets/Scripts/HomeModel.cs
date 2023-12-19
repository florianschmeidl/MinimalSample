using System;
using UnityEngine;

public class HomeModel
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

    // Members
    private string m_UserName;
    
    // Constructors
    public HomeModel(IUserService userService)
    {
        m_UserService = userService;
        
        if (m_UserService.IsLoggedIn)
        {
            UserName = m_UserService.LoggedInUser;
        }
    }
    
    // Methods
    public async Awaitable TryLogOut()
    {
        await m_UserService.LogOut();
        m_UserName = "";
    }
}