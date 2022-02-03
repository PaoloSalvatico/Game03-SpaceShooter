using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class ShooterExample : MonoBehaviour
    {
        public ObjectPoolerExample pool;

        public float fireInterval = .1f;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine("SpawnSequence");
        }

        IEnumerator SpawnSequence()
        {
            while (true)
            {
                var go = pool.GetObject();
                if(go != null)
                {
                    go.transform.position = transform.position;
                    go.transform.rotation = transform.rotation;
                }
                yield return new WaitForSeconds(fireInterval);
            }
        }
    }
}
