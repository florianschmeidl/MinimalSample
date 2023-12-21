using StateHandling.Handlers;
using Straumann.Core;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class StateInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<IApplicationState, LoginState>(Lifetime.Scoped);
            builder.Register<IApplicationState, HomeState>(Lifetime.Scoped);
            builder.Register<IApplicationState, CasesState>(Lifetime.Scoped);
            builder.Register<IApplicationState, Case3dState>(Lifetime.Scoped);
        }
    }
}