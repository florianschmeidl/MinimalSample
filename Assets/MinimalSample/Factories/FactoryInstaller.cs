using UnityEngine;using VContainer;
using VContainer.Unity;

public class FactoryInstaller : MonoBehaviour, IInstaller
{
    //TODO: Delete
    public void Install(IContainerBuilder builder)
    {
        builder.Register<IMVVMFactory, MVVMFactory>(Lifetime.Singleton);
    }
}