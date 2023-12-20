using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

public class LoginViewModel : IInitializable, IStartable
{
    // Dependencies
    private readonly LoginModel m_LoginModel;

    // Properties
    [CreateProperty]
    public string UserName { get; set; } = "Test1";

    [CreateProperty]
    public string Password { get; set; } = "PW1";

    [CreateProperty]
    public DisplayStyle ErrorVisibility { get; set; } = DisplayStyle.None;

    [CreateProperty]
    public string ErrorText { get; set; } = "";

    [CreateProperty] 
    public DisplayStyle LoadingVisibility { get; set; } = DisplayStyle.None;

    [CreateProperty] 
    public Action ButtonClicked { get; private set; }

    // Constructors
    public LoginViewModel(LoginModel loginModel)
    {
        Debug.Log($"[{this}] Constructor called!");
        ButtonClicked = HandleButtonClicked;
        m_LoginModel = loginModel;
    }

    // Entrypoints
    void IInitializable.Initialize()
    {
        Debug.Log($"[{this}] Initialized!");
        m_LoginModel.LoginModelUpdated += UpdateFromModel;
    }

    void IStartable.Start()
    {
        Debug.Log($"[{this}] Started!");
    }

    // Callback for model updated
    private void UpdateFromModel(LoginModelChangedEventArgs loginModelChangedEventArgs)
    {
        Debug.Log($"[{this}] Received update from model!");

        this.UserName = loginModelChangedEventArgs.UserName;
        this.Password = loginModelChangedEventArgs.Password;
    }

    // Handlers for user interactions
    private async void HandleButtonClicked()
    {
        Debug.Log($"[{this}] HandleButtonClicked!");

        Debug.Log($"[{this}] UserName: {this.UserName}!");
        Debug.Log($"[{this}] Password: {this.Password}!");

        LoadingVisibility = DisplayStyle.Flex;

        var success = await m_LoginModel.TryLogIn();

        LoadingVisibility = DisplayStyle.None;

        if (success)
        {
            // Change to HomeView
        }
        else
        {
            ErrorText = "Password wrong";
            ErrorVisibility = DisplayStyle.Flex;
            this.UserName = "";
            this.Password = "";
        }
    }
}
