using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class CoreInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<IApplicationStateManager, ApplicationStateManager>(Lifetime.Singleton);
        }
    }
}