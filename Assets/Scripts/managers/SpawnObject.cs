using System;
using System.Collections;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private ObjectPool objectPool;
    [SerializeField] private string pooledObjectId;

    private float currentX = 0;
    public void Spawn(string pooledObjectId)
    {
        var go = objectPool.GetObject(pooledObjectId);
        if (go != null)
        {
            go.transform.position = new Vector3(currentX, 0, 0);
            go.transform.rotation = Quaternion.identity;
            currentX++;
            //Invoke("ReturnObject",go, 1f);
            StartCoroutine(ReturnObject(go));
        }
        else
        {
            Debug.LogWarning($"No object found with ID: {pooledObjectId}");
        }
    }
    
    private IEnumerator ReturnObject(GameObject go)
    {
        yield return new WaitForSeconds(1f);
        objectPool.ReturnObject(pooledObjectId, go);
        currentX = 0; 
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Spawn Object"))
        {
            Spawn(pooledObjectId);
        }
    }
}
