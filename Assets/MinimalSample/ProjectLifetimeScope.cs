using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ProjectLifetimeScope : LifetimeScope
{
    [SerializeField] private LoginLifetimeScope m_LoginView;

    protected override void Configure(IContainerBuilder builder)
    {
        var installers = this.GetComponentsInChildren<IInstaller>();
        foreach (var installer in installers)
        {
            installer.Install(builder);
        }
        
        // Instantiate first view
        builder.RegisterBuildCallback(resolver =>
        {
            var uiVisualsHandler = resolver.Resolve<UIVisualsHandler>();
            resolver.Resolve<IApplicationStateManager>().SetState(ApplicationState.Login);
        });
    }
}
