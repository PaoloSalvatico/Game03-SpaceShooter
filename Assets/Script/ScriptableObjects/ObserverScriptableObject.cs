using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu(fileName = "Observer", menuName = "Space Shooter/Observer")]
    public class ObserverScriptableObject : ScriptableObject
    {
        public delegate void Notifier(GameObject notifier = null);
        public Notifier OnNotify;

        public void Notify(GameObject notifier = null)
        {
            if (OnNotify != null) OnNotify(notifier);
        }
    }

}
