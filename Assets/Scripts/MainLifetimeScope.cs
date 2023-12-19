using UnityEngine;
using VContainer;

public class MainLifetimeScope : MonoBehaviour
{
    [SerializeField] private GameObject m_LoginView;

    public void Start()
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterInstance(m_LoginView);
        containerBuilder.Register<ViewFactory>(Lifetime.Scoped);
        var objectResolver = containerBuilder.Build();
        
        objectResolver.Resolve<ViewFactory>();
    }
    

}
