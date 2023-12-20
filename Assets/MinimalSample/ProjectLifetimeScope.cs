using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ProjectLifetimeScope : LifetimeScope
{
    [SerializeField] private LoginLifetimeScope m_LoginView;

    protected override void Configure(IContainerBuilder builder)
    {
        // Register business logic
        builder.RegisterBusinessLogic();

        // Register factories
        builder.RegisterFactories();

        // Instantiate first view
        builder.RegisterBuildCallback(resolver =>
        {
            resolver.Resolve<IMVVMFactory>().Create(m_LoginView);
        });
    }
}
