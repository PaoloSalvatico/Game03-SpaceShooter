using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class PoolSpawner : MonoBehaviour
    {
        public ObjectPoolScriptableObject pool;

        public float minSpawnTime = .5f;
        public float maxSpawnTime = 1f;

        public int spawnedItems = 10;

        private int _spawnCount;

        void Start()
        {
            var cam = Camera.main;
            var screenSize = cam.ViewportToWorldPoint(Vector2.one);
            var screenWidth = screenSize.x;
            var screenHeight = screenSize.y;

            transform.position = new Vector3(0, screenHeight, 0);

            StartCoroutine(SpawnSequence());
        }

        IEnumerator SpawnSequence()
        {
            while(_spawnCount <= spawnedItems)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
                if (spawnedItems > 0)
                    _spawnCount++;
                var go = pool.GetObject();
                go.transform.position = transform.position;
                go.transform.rotation = transform.rotation;
            }
        }

    }
}
