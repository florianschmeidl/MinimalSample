using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Installers
{
    public class ViewModelInstaller : MonoBehaviour, IInstaller
    {
        public void Install(IContainerBuilder builder)
        {
            builder.Register<LoginViewModel>(Lifetime.Singleton);
            builder.Register<LoginModel>(Lifetime.Singleton);
        }
    }
}