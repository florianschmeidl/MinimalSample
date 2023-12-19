using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class LoginLifetimeScope : LifetimeScope
{
    [SerializeField] private UIDocument m_UIDocument;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent<UIDocument>(m_UIDocument);
        builder.Register<LoginModel>(Lifetime.Scoped);
        builder.RegisterEntryPoint<LoginViewModel>(Lifetime.Scoped);
    }
}
