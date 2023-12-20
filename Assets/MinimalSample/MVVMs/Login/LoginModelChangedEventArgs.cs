﻿public delegate void LoginModelUpdated(LoginModelChangedEventArgs loginModelChangedEventArgs);

public readonly struct LoginModelChangedEventArgs
{
    public readonly string UserName;
    public readonly string Password;

    public LoginModelChangedEventArgs(string userName, string password)
    {
        this.UserName = userName;
        this.Password = password;
    }
}