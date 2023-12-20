using UnityEngine;

public class MVVMFactory : IMVVMFactory
{
    public T Create<T>(T prefab) where T : Component
    {
        return Create<T>(prefab, null);
    }

    public T Create<T>(T prefab, Transform transform) where T : Component
    {
        Debug.Log($"[{this}] Created {typeof(T)}");
        return GameObject.Instantiate(prefab, transform);
    }
}