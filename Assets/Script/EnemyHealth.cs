using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyHealth : MonoBehaviour
    {
        public ObserverScriptableObject shipDestroyedNotifier;

        public void Damage(GameObject provoker)
        {
            Debug.Log("Damaged by: " + provoker);
            shipDestroyedNotifier.Notify(gameObject);
            gameObject.SetActive(false);
        }
    }

}
