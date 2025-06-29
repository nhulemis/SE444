using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MyObject : MonoBehaviour
{
    [SerializeField] private bool m_IsPooled = true;
    [SerializeField] private int m_PoolSize = 10;
    private bool m_isInitialized = false;
    
    public void Spawn(Vector3 pos , Quaternion rot)
    {
        InitializePool();
        var go = ObjectPool.Instance.GetObject(gameObject);
        go.transform.SetPositionAndRotation(pos, rot);
    }

    private void InitializePool()
    {
        if (m_isInitialized) return;
        m_isInitialized = true;
        ObjectPool.Instance.InitializePool(gameObject, m_PoolSize);
    }
}
