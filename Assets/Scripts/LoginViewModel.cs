using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

public class LoginViewModel : IStartable
{
    // Dependencies
    private readonly UIDocument m_LoginUIDocument;
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

    // Constructors
    public LoginViewModel(UIDocument loginUIDocument, LoginModel loginModel)
    {
        m_LoginUIDocument = loginUIDocument;
        m_LoginModel = loginModel;

        UpdateFromModel(null, EventArgs.Empty);
        m_LoginModel.Changed += UpdateFromModel;
        
        Initialize();
    }

    private void UpdateFromModel(object sender, EventArgs e)
    {
        this.UserName = m_LoginModel.UserName;
        this.Password = m_LoginModel.Password;
    }

    private async Awaitable Initialize()
    {
        await Awaitable.NextFrameAsync();
        
        m_LoginUIDocument.rootVisualElement.dataSource = this;
        var button = m_LoginUIDocument.rootVisualElement.Query<Button>().First();
        button.clicked += HandleButtonClicked;
    }

    private async void HandleButtonClicked()
    {
        Debug.Log(this.UserName);
        Debug.Log(this.Password);

        LoadingVisibility = DisplayStyle.Flex;

        var success = await m_LoginModel.TryLogIn();

        LoadingVisibility = DisplayStyle.None;

        if (success)
        {
        }
        else
        {
            ErrorText = "Password wrong";
            ErrorVisibility = DisplayStyle.Flex;
            this.UserName = "";
            this.Password = "";
        }
    }

    void IStartable.Start()
    {
        Debug.Log(this.UserName);
        Debug.Log(this.Password);
    }
}
