using System;
using System.Linq;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer.Unity;

public class CasesViewModel : IStartable, IInitializable
{
    // Dependencies
    private readonly UIDocument m_CasesUIDocument;
    
    // Constructors
    public CasesViewModel(UIDocument casesUIDocument)
    {
        m_CasesUIDocument = casesUIDocument;
    }

    void IInitializable.Initialize()
    {
        m_CasesUIDocument.rootVisualElement.dataSource = this;
        var openCase1Button = m_CasesUIDocument.rootVisualElement.Query<Button>().Where(x => x.name == "OpenCase1Button").First();
        var closeCase1Button = m_CasesUIDocument.rootVisualElement.Query<Button>().Where(x => x.name == "CloseCase1Button").First();
        var openCase2Button = m_CasesUIDocument.rootVisualElement.Query<Button>().Where(x => x.name == "OpenCase2Button").First();
        var closeCase2Button = m_CasesUIDocument.rootVisualElement.Query<Button>().Where(x => x.name == "CloseCase2Button").First();
        var backButton = m_CasesUIDocument.rootVisualElement.Query<Button>().Where(x => x.name == "BackButton").First();
        openCase1Button.clicked += HandleOpenCase1Button;
        closeCase1Button.clicked += HandleCloseCase1Button;
        openCase2Button.clicked += HandleOpenCase2Button;
        closeCase2Button.clicked += HandleCloseCase2Button;
        backButton.clicked += HandleBackButton;
    }

    private void HandleBackButton()
    {
        Debug.Log("Back");
    }

    private void HandleCloseCase2Button()
    {
        Debug.Log("Close Case 2");
    }

    private void HandleOpenCase2Button()
    {
        Debug.Log("Open Case 2");
    }

    private void HandleCloseCase1Button()
    {
        Debug.Log("Close Case 1");
    }

    private void HandleOpenCase1Button()
    {
        Debug.Log("Open Case 1");
    }
    

    void IStartable.Start()
    {
        Debug.Log("Starting Cases");
    }
}