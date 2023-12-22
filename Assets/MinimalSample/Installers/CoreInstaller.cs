using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class CoreInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<StateSetter>(Lifetime.Scoped);
            builder.Register<IApplicationStateManager, ApplicationStateManager>(Lifetime.Singleton);
            builder.RegisterNonLazy<Aggregate>(Lifetime.Singleton);
        }
    }
}