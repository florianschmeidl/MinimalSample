using UnityEngine;

public interface IUserService
{
    bool IsLoggedIn { get; set; }
    string LoggedInUser { get; set; }
    Awaitable<bool> LogIn(string userName, string password);
}