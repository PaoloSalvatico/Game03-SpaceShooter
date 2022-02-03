using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu(fileName = "ObjectPool", menuName = "Space Shooter/Object Pool")]
    public class ObjectPoolScriptableObject : ScriptableObject
    {

        [SerializeField]
        protected GameObject _prefab;

        protected List<GameObject> _pool;

        [SerializeField]
        protected int _startingPoolSize;

        [SerializeField]
        protected bool _openPool;

        protected GameObject _container;

        protected bool _initialized;

        /// <summary>
        /// Inizializza il pool
        /// </summary>
        public void Init()
        {
            if(_container == null)
            {
                _container = new GameObject("Pool: " + _prefab.name);
            }

            _pool = new List<GameObject>();

            for(int i = 0; i < _startingPoolSize; i++)
            {
                CreateObject();
            }
            _initialized = true;
        }

        public void Cleanup()
        {
            _pool.Clear();
            _initialized = false;
        }

        /// <summary>
        /// Ritorna un oggetto dal pool, se disponibile
        /// </summary>
        /// <returns></returns>
        public GameObject GetObject()
        {
            if (!_initialized) Init();

            foreach (var go in _pool)
            {
                if (!go.activeInHierarchy)
                {
                    go.SetActive(true);
                    return go;
                }
            }
            if(_openPool) return CreateObject(true);
            return null;
        }

        /// <summary>
        /// Crea un oggetto e lo inserisce nel poll
        /// </summary>
        /// <param name="startEnabled">Indica se l'oggetto deve essere ritornato abilitato oppure no</param>
        /// <returns>L'oggetto creato</returns>
        protected GameObject CreateObject(bool startEnabled = false)
        {
            var go = Instantiate(_prefab);
            go.SetActive(startEnabled);
            go.transform.SetParent(_container.transform);
            _pool.Add(go);
            return go;
        }
    }
}
