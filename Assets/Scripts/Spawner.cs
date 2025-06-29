using UnityEngine;

public sealed class Spawner : MonoBehaviour
{
    [SerializeField]
    public MyObject m_Prefab;
    private void SpawnObject(Vector3 pos)
    {
        m_Prefab.Spawn(pos , Quaternion.identity);
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnObject(Vector3.up);
        }
    }
}
