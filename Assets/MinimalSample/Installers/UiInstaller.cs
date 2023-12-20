using Straumann.UI;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class UiInstaller : MonoBehaviour, IInstaller
{
    [SerializeField] private VisualTreeDatabase m_VisualTreeDatabase;
    [SerializeField] private PanelSettings m_PanelSettings;
    
    public void Install(IContainerBuilder builder)
    {
        builder.Register<IUIFactory, UIFactory>(Lifetime.Singleton);
        builder.RegisterInstance<IVisualTreeDatabase>(m_VisualTreeDatabase);
        builder.RegisterInstance<PanelSettings>(m_PanelSettings);
        builder.Register<IVisualTreeProvider, VisualTreeProvider>(Lifetime.Scoped);
        builder.Register<UIVisualsHandler>(Lifetime.Singleton);
    }
}