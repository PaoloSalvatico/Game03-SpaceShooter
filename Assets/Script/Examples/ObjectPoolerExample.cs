using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class ObjectPoolerExample : MonoBehaviour
    {
        public List<GameObject> pool;

        public GameObject prefab;

        public int poolSize;

        void Start()
        {
            pool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                CreateObject();
            }
        }

        public GameObject GetObject()
        {
            foreach (var go in pool)
            {
                if (!go.activeInHierarchy)
                {
                    go.SetActive(true);
                    return go;
                }
            }
            return CreateObject(true);
        }

        protected GameObject CreateObject(bool startEnabled = false)
        {
            var go = Instantiate(prefab);
            go.SetActive(startEnabled);
            pool.Add(go);
            return go;
        }

    }
}
