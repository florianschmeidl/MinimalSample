using System;
using System.Threading.Tasks;
using Straumann.UI;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

public class UIVisualsHandler
{
    // Dependencies
    private readonly IApplicationStateManager m_ApplicationStateManager;
    private readonly IUIFactory m_UIFactory;
    private readonly IObjectResolver m_ObjectResolver;
    
    // Members
    private UIDocument m_LoginView;

    // Constructors
    public UIVisualsHandler(IApplicationStateManager applicationStateManager, IUIFactory uiFactory, IObjectResolver objectResolver)
    {
        m_ApplicationStateManager = applicationStateManager;
        m_UIFactory = uiFactory;
        m_ObjectResolver = objectResolver;
        m_ApplicationStateManager.ApplicationStateChanged += HandleApplicationStateChanged;
    }

    private async void HandleApplicationStateChanged(object sender, ApplicationStateChangedArgs e)
    {
        switch (e.NewState)
        {
            case ApplicationState.Initialize:
                break;
            case ApplicationState.Login:
                await CreateLoginView();
                break;
            case ApplicationState.Work:
                DestroyLoginView();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private async Task CreateLoginView()
    {
        if (m_LoginView == null)
        {
            m_LoginView = await m_UIFactory.Make("LoginView");
            await Awaitable.NextFrameAsync();
            var loginViewModel = m_ObjectResolver.Resolve<LoginViewModel>();
            m_LoginView.rootVisualElement.dataSource = loginViewModel;
        }
    }
    
    private void DestroyLoginView()
    {
        if (m_LoginView != null)
        {
            var transform = m_LoginView.transform.parent;
            GameObject.Destroy(transform.gameObject);
        }
    }
}
