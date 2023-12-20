using UnityEngine;

public interface IMVVMFactory
{
    T Create<T>(T prefab) where T : Component;
    T Create<T>(T prefab, Transform transform) where T : Component;
}