using VContainer;
using VContainer.Unity;

public class ProjectLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        var installers = GetComponentsInChildren<IInstaller>();
        foreach (var installer in installers)
        {
            installer.Install(builder);
        }
    }
}