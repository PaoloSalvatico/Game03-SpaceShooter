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

        [SerializeField]
        protected float _rotationSpeed = 20;

        [SerializeField]
        [Space(10)]
        protected CurveScriptableObject _movementCurve;

        [Header("Weapon System")]
        [SerializeField]
        protected ObjectPoolScriptableObject _primaryWeaponPool;

        [SerializeField]
        protected ObjectPoolScriptableObject _secondaryWeaponPool;

        public float ForwardSpeed
        {
            get
            {
                return _forwardSpeed;
            }
            set
            {
                _forwardSpeed = value;
            }
        }
        public float SideSpeed
        {
            get
            {
                return _sideSpeed;
            }
            set
            {
                _sideSpeed = value;
            }
        }

        public  float RotateSpeed
        {
            get
            {
                return _rotationSpeed;
            }
            set
            {
                _rotationSpeed = value;
            }
        }

        public ObjectPoolScriptableObject PrimaryWeaponPool
        {
            get
            {
                return _primaryWeaponPool;
            }
            set
            {
                _primaryWeaponPool = value;
            }
        }

        public ObjectPoolScriptableObject SecondaryWeaponPool
        {
            get
            {
                return _secondaryWeaponPool;
            }
            set
            {
                _secondaryWeaponPool = value;
            }
        }

        public CurveScriptableObject MovementCurve
        {
            get
            {
                return _movementCurve;
            }
            set
            {
                _movementCurve = value;
            }
        }

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
