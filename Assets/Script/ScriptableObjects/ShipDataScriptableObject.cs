using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Contenitore di dati e statistiche di una navicella.
    /// </summary>
    [CreateAssetMenu(fileName = "ShipData", menuName = "Space Shooter/Ship Data")]
    public class ShipDataScriptableObject : ScriptableObject
    {
        [Header("Movement")]
        [SerializeField]
        protected float _forwardSpeed = 5;

        [SerializeField]
        protected float _sideSpeed = 3;

        [Header("Weapon System")]
        [SerializeField]
        protected ObjectPoolScriptableObject _primaryWeaponPool;

        [SerializeField]
        protected ObjectPoolScriptableObject _secondaryWeaponPool;

        public float ForwardSpeed { get { return _forwardSpeed; } }
        public float SideSpeed { get { return _forwardSpeed; } }
        public GameObject PrimaryBullet {
            get
            {
                if(_primaryWeaponPool != null) return _primaryWeaponPool.GetObject();
                return null;
            }
        }
        
        public GameObject SecondaryBullet {
            get
            {
                if (_secondaryWeaponPool != null) return _secondaryWeaponPool.GetObject();
                return null;
            }
        }

    }

}
