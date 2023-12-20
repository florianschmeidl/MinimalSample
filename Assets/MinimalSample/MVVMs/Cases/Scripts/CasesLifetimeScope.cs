using System;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;
using VContainer.Unity;

public class CasesLifetimeScope : LifetimeScope
{
    [SerializeField] private UIDocument m_UIDocument;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent<UIDocument>(m_UIDocument);
        builder.RegisterEntryPoint<CasesViewModel>(Lifetime.Scoped);
    }
}



