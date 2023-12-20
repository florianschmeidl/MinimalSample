using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

public class HomeViewModel : IStartable, IInitializable
{
    // Dependencies
    private readonly UIDocument m_LoginUIDocument;
    private readonly HomeModel m_HomeModel;

    // Properties
    [CreateProperty]
    public string HelloLabel { get; set; } = "Hello XY";
    
    [CreateProperty]
    public DisplayStyle LoadingVisibility { get; set; } = DisplayStyle.None;
    
    // Constructors
    public HomeViewModel(UIDocument loginUIDocument, HomeModel homeModel)
    {
        m_LoginUIDocument = loginUIDocument;
        m_HomeModel = homeModel;       
    }

    void IInitializable.Initialize()
    {
        UpdateFromModel(null, EventArgs.Empty);
        m_HomeModel.Changed += UpdateFromModel;
        m_LoginUIDocument.rootVisualElement.dataSource = this;
        var casesButton = m_LoginUIDocument.rootVisualElement.Query<Button>().Where(x => x.name == "CasesButton").First();
        var logoutButton = m_LoginUIDocument.rootVisualElement.Query<Button>().Where(x => x.name == "LogOutButton").First();
        casesButton.clicked += HandleCasesButtonClicked;
        logoutButton.clicked += HandleLogOutButtonClicked;
    }

    private void UpdateFromModel(object sender, EventArgs e)
    {
        this.HelloLabel = $"Hello {m_HomeModel.UserName}";
    }

    private async void HandleLogOutButtonClicked()
    {
        LoadingVisibility = DisplayStyle.Flex;

        await m_HomeModel.TryLogOut();

        Debug.Log("Logout");
        
        LoadingVisibility = DisplayStyle.None;
    }

    private void HandleCasesButtonClicked()
    {
        LoadingVisibility = DisplayStyle.Flex;
        
        Debug.Log("Cases");
        // open cases
        
        LoadingVisibility = DisplayStyle.None;
    }

    void IStartable.Start()
    {
        Debug.Log("Starting Home");
    }
}