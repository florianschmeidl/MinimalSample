using VContainer;
using VContainer.Unity;

public class BusinessLogicLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IUserService, UserService>(Lifetime.Singleton);
    }
}
