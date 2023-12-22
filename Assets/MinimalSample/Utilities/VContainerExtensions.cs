using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public static class VContainerExtensions
{
    public static GameObject InstantiateAndInject([NotNull] this IObjectResolver resolver, [NotNull] GameObject prefab, Transform parent = null)
    {
        if (prefab == null)
            throw new NullReferenceException(nameof(prefab));

        var prefabActive = prefab.activeSelf;

        prefab.SetActive(false);
        var instance = resolver.Instantiate(prefab, parent);
        prefab.SetActive(prefabActive);

        instance.SetActive(prefabActive);
        return instance;
    }

    public static GameObject InstantiateWithScope([NotNull] this LifetimeScope scope, [NotNull] GameObject prefab, Transform parent = null)
    {
        if (prefab == null)
            throw new NullReferenceException(nameof(prefab));

        var prefabActive = prefab.activeSelf;
        prefab.SetActive(false);

        using var disposable = LifetimeScope.EnqueueParent(scope);
        var instance = UnityEngine.Object.Instantiate(prefab, parent);

        try
        {
            if (!instance.TryGetComponent<LifetimeScope>(out _))
                scope.Container.InjectGameObject(instance);
        }
        finally
        {
            instance.SetActive(prefabActive);
            prefab.SetActive(prefabActive);
        }

        return instance;
    }
    public static T InstantiateWithScope<T>([NotNull] this LifetimeScope scope, [NotNull] T prefab, Transform parent = null)
        where T : Component
    {
        if (prefab == null)
            throw new NullReferenceException(nameof(prefab));

        var prefabActive = prefab.gameObject.activeSelf;
        prefab.gameObject.SetActive(false);

        using var disposable = LifetimeScope.EnqueueParent(scope);
        var instance = UnityEngine.Object.Instantiate(prefab, parent);

        prefab.gameObject.SetActive(prefabActive);

        try
        {
            if (!instance.TryGetComponent<LifetimeScope>(out _))
                scope.Container.InjectGameObject(instance.gameObject);
        }
        finally
        {
            instance.gameObject.SetActive(prefabActive);
        }

        return instance;
    }

    public static T InstantiateAndInject<T>(this IObjectResolver resolver, [NotNull] T prefab, Transform parent = null)
        where T : Component
    {
        if (prefab == null)
            throw new NullReferenceException(nameof(prefab));

        var prefabActive = prefab.gameObject.activeSelf;
        prefab.gameObject.SetActive(false);
        var instance = resolver.Instantiate(prefab, parent);
        instance.gameObject.SetActive(prefabActive);
        prefab.gameObject.SetActive(prefabActive);
        return instance;
    }

    public static T CreateComponentOnNewGameObjectAndInject<T>(this IObjectResolver resolver, string gameObjectName = null)
        where T : Component
    {
        if (string.IsNullOrWhiteSpace(gameObjectName))
            gameObjectName = typeof(T).Name;

        var gameObject = new GameObject(gameObjectName);
        gameObject.SetActive(false);
        var component = gameObject.AddComponent<T>();
        resolver.InjectGameObject(gameObject);
        gameObject.SetActive(true);

        return component;
    }

    public static RegistrationBuilder RegisterFromPrefabWithInject(this IContainerBuilder builder, GameObject prefab, Lifetime lifetime)
    {
        return builder.Register(Instantiate, lifetime);

        GameObject Instantiate(IObjectResolver resolver) => resolver.InstantiateAndInject(prefab);
    }

    public static RegistrationBuilder RegisterFromPrefabWithInject<T>(this IContainerBuilder builder, T prefab, Lifetime lifetime)
        where T : Component
    {
        return builder.Register(Instantiate, lifetime);

        T Instantiate(IObjectResolver resolver) => resolver.InstantiateAndInject(prefab);
    }

    public static RegistrationBuilder RegisterFromPrefabWithInject(this IContainerBuilder builder, Func<IObjectResolver, GameObject> prefab, Lifetime lifetime)
    {
        return builder.Register(Instantiate, lifetime);

        GameObject Instantiate(IObjectResolver resolver) => resolver.InstantiateAndInject(prefab(resolver));
    }

    public static RegistrationBuilder RegisterFromPrefabWithInject<T>(this IContainerBuilder builder, Func<IObjectResolver, T> prefab, Lifetime lifetime)
        where T : Component
    {
        return builder.Register(Instantiate, lifetime);

        T Instantiate(IObjectResolver resolver) => resolver.InstantiateAndInject(prefab(resolver));
    }
    public static void RegisterNonLazy<T>(this IContainerBuilder builder, Lifetime lifetime)
    {
        builder.Register<T>(lifetime);
        builder.RegisterBuildCallback(resolver => resolver.Resolve<T>());
    }
}