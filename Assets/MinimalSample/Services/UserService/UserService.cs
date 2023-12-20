using UnityEngine;

public class UserService : IUserService
{
    // Dependencies
    private readonly IUserRepository m_UserRepository;

    // Properties
    public bool IsLoggedIn { get; set; } = false;
    public string LoggedInUser { get; set; } = "";

    public UserService(IUserRepository userRepository)
    {
        Debug.Log($"[{this}] Constructor called!");

        m_UserRepository = userRepository;
    }

    // Methods
    public async Awaitable<bool> LogIn(string userName, string password)
    {
        Debug.Log($"[{this}] Trying to log in...!");
        await Awaitable.WaitForSecondsAsync(1);

        if(RandomTrueOrFalseUtility.RandomTrueOrFalse == true)
        {
            Debug.Log($"[{this}] Login success!");
            IsLoggedIn = true;
            LoggedInUser = userName;
            return true;
        }
        else
        {
            Debug.Log($"[{this}] Login failed!");
            IsLoggedIn = true;
            return false;
        }
    }

    public Awaitable LogOut()
    {
        throw new System.NotImplementedException();
    }
}