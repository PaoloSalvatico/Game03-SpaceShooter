using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [AddComponentMenu("SpaceShooter/PoolMAnager")]
    public class PoolManager : MonoBehaviour
    {
        public ObjectPoolScriptableObject[] poolList;

        void Start()
        {
            foreach(var pool in poolList)
            {
                pool.Init();
            }
        }

        private void OnApplicationQuit()
        {
            foreach (var pool in poolList)
            {
                pool.Cleanup();
            }
        }
    }
}
