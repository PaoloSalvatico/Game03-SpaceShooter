using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShooter
{
    /// <summary>
    /// Componente che permette di gestire la navicella da parte del giocatore
    /// Mantiene i dati principali e il sistema di input
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("SpaceShooter/PlayerShipController")]
    public class PlayerShipController : AbstractShipController
    {
        protected GameInput _playerControls;

        protected AbilityShoot[] _shootAbilities;
        protected PlayerMovement _playerMovement;

        public GameObject testGameObject;

        private void Awake()
        {
            _playerControls = new GameInput();

            _playerControls.Player.FirePrimary.started += OnPrimaryFire;
            _playerControls.Player.FirePrimary.canceled += OnPrimaryFire;
            _playerControls.Player.FireSecondary.started += OnSecondaryFire;
            _playerControls.Player.FireSecondary.canceled += OnSecondaryFire;
        }

        protected override void Start()
        {
            base.Start();

            _shootAbilities = GetComponents<AbilityShoot>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        #region Shoot Logic
        private void OnPrimaryFire(InputAction.CallbackContext context)
        {
            ExecuteShootCommands(WeaponType.Primary, context);
        }

        private void OnSecondaryFire(InputAction.CallbackContext context)
        {
            ExecuteShootCommands(WeaponType.Secondary, context);
        }

        private void ExecuteShootCommands(WeaponType type, InputAction.CallbackContext context)
        {
            foreach (var shoot in _shootAbilities)
            {
                if (context.started && shoot.weaponType == type)
                {
                    shoot.StartAbility();
                }
                else if (context.canceled && shoot.weaponType == type)
                {
                    shoot.EndAbility();
                }
            }
        }

        #endregion

        protected virtual void OnEnable()
        {
            _playerControls.Player.Enable();
        }

        protected virtual void OnDisable()
        {
            _playerControls.Player.Disable();
        }

        protected virtual void FixedUpdate()
        {
            var amount = _playerControls.Player.Move.ReadValue<Vector2>();
            _playerMovement.Move(amount);
        }
    }
}
