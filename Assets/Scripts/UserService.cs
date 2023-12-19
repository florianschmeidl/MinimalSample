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
        m_UserRepository = userRepository;
    }

    // Methods
    public async Awaitable<bool> LogIn(string userName, string password)
    {
        await Awaitable.WaitForSecondsAsync(5);

        var user = m_UserRepository.Read(userName);
        if (user != null && user.Password == password)
        {
            IsLoggedIn = true;
            LoggedInUser = userName;
            return true;
        }
        else
        {
            IsLoggedIn = false;
            return false;
        }
    }
}
