using VContainer;

public static class FactoryInstaller
{
    public static void RegisterFactories(this IContainerBuilder builder)
    {
        builder.Register<IMVVMFactory, MVVMFactory>(Lifetime.Singleton);
    }
}