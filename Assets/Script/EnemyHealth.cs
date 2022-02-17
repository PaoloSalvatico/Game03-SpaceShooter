using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyHealth : MonoBehaviour
    {
        public ObserverScriptableObject shipdestroydNotifier;

        public void Damage(GameObject provoker)
        {
            Debug.Log("Damaged by " + provoker);
            shipdestroydNotifier.Notify(gameObject);
            gameObject.SetActive(false);
        }
    }
}

