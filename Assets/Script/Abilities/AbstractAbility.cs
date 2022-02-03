using SpaceShooter.Interfaces;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Classe astratta per l'implementazione di abilità utilizzabili da una nave (giocatore, AI, etc.)
    /// </summary>
    [RequireComponent(typeof(AbstractShipController))]
    public abstract class AbstractAbility : MonoBehaviour, ICommandStartAbility, ICommandEndAbility
    {
        [SerializeField]
        protected bool _isActive = true;

        protected AbstractShipController _controller;

        protected ShipDataScriptableObject _data;

        protected virtual void Start()
        {
            _controller = GetComponent<AbstractShipController>();
            _data = _controller.Data;
        }

        public abstract void StartAbility();

        public abstract void EndAbility();

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                if (!_isActive) EndAbility();
            }
        }
    }

}
