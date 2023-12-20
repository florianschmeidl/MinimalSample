using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class HomeLifetimeScope : LifetimeScope
{
    [SerializeField] private UIDocument m_UIDocument;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent<UIDocument>(m_UIDocument);
        builder.Register<HomeModel>(Lifetime.Scoped);
        builder.RegisterEntryPoint<HomeViewModel>(Lifetime.Scoped);
    }
}



