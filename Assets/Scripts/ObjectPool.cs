using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectPool : Singleton<ObjectPool>
    {
        private Dictionary<int, List<GameObject>> _pools = new();
        
        public void InitializePool(GameObject obj, int size)
        {
            int key = obj.GetInstanceID();
            if (!_pools.ContainsKey(key))
            {
                _pools[key] = new List<GameObject>();
            }

            for (int i = 0; i < size; i++)
            {
                GameObject pooledObject = Instantiate(obj);
                pooledObject.SetActive(false);
                _pools[key].Add(pooledObject);
            }
        }
        
        public GameObject GetObject(GameObject obj)
        {
            int key = obj.GetInstanceID();
            if (_pools.ContainsKey(key) && _pools[key].Any())
            {
                GameObject pooledObject = _pools[key].FirstOrDefault(
                    o => !o.activeInHierarchy);
                if (pooledObject != null)
                {
                    pooledObject.SetActive(true);
                    return pooledObject;
                }
            }
            
            // create a new object if no pooled object is available
            GameObject newObject = Instantiate(obj);
            newObject.SetActive(true);
            if (!_pools.ContainsKey(key))
            {
                _pools[key] = new List<GameObject>();
            }
            _pools[key].Add(newObject);
            return newObject;
        }
    }
}