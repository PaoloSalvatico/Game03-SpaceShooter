using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LevelManager : MonoBehaviour
    {
        public ObserverScriptableObject pointsObserver;
        public ObserverScriptableObject playerObserver;

        private void OnEnable()
        {
            pointsObserver.OnNotify += OnNotify;
        }

        private void OnDisable()
        {
            pointsObserver.OnNotify -= OnNotify;

        }

        void OnNotify(GameObject go)
        {
            var enemyShip = go.GetComponent<EnemyShipController>();
            if (enemyShip == null) return; 
            Debug.Log("Destroyed: " + enemyShip.points);
        }
    }

}
