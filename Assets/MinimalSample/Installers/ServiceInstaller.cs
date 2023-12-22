using DefaultNamespace;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ServiceInstaller : MonoBehaviour, IInstaller
{
    public void Install(IContainerBuilder builder)
    {
        // UserService
        builder.Register<IUserService, UserService>(Lifetime.Singleton);
        builder.Register<IUserRepository, UniversalUserRepository>(Lifetime.Singleton);
        builder.Register<LocalJsonUserRepository>(Lifetime.Singleton);
        builder.Register<SqLiteUserRepository>(Lifetime.Singleton);

        // OnlineState
        builder.Register<IOnlineStateProvider, OnlineStateProvider>(Lifetime.Singleton);
        
        // CaseService
        builder.Register<ICurrentCaseService, CurrentCaseService>(Lifetime.Singleton);
    }
}