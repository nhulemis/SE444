using System;
using System.Collections.Generic;
using DefaultNamespace;
using Unity.Collections;
using UnityEngine;

public class ObjectManager : Singleton<ObjectManager>
{
    [SerializeField,ReadOnly]
    private List<GameObject> m_Objects;

    private void Start()
    {
        m_Objects = new  List<GameObject>();
    }
    
    public void RegisterObject(GameObject obj)
    {
        if (!m_Objects.Contains(obj))
        {
            m_Objects.Add(obj);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ClearAllObjects();
        }
    }

    public void ClearAllObjects()
    {
        foreach (var obj in m_Objects)
        {
        }
        m_Objects.Clear();
    }
}
