using DefaultNamespace;
using VContainer;

public static class ServiceInstaller
{
    public static void RegisterBusinessLogic(this IContainerBuilder builder)
    {
        // UserService
        builder.Register<IUserService, UserService>(Lifetime.Singleton);
        builder.Register<IUserRepository, UniversalUserRepository>(Lifetime.Singleton);
        builder.Register<LocalJsonUserRepository>(Lifetime.Singleton);
        builder.Register<SqLiteUserRepository>(Lifetime.Singleton);

        // OnlineState
        builder.Register<IOnlineStateProvider, OnlineStateProvider>(Lifetime.Singleton);
    }
}