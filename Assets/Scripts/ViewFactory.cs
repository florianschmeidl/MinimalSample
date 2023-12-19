using UnityEngine;

public class ViewFactory
{
    private readonly GameObject m_Prefab;

    public ViewFactory(GameObject prefab)
    {
        m_Prefab = prefab;
        GameObject.Instantiate(m_Prefab);
    }
}
