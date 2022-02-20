using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    /// <summary>
    /// Handles player movement
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [AddComponentMenu("SpaceShooter/Player Movement")]
    public class PlayerMovement : MonoBehaviour
    {
        protected Rigidbody2D _rb;

        protected AbstractShipController _controller;

        protected ShipDataScriptableObject _data;

        /// <summary>
        /// Retrieves all components
        /// </summary>
        protected virtual void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _controller = GetComponent<AbstractShipController>();
            _data = _controller.Data;
        }

        /// <summary>
        /// Moves the ship by interpolating the new input with the actual velocity
        /// </summary>
        /// <param name="amount">The new input directio</param>
        public virtual void Move(Vector2 amount)
        {
            var speed = new Vector2(amount.x * _data.SideSpeed, amount.y * _data.ForwardSpeed);
            _rb.velocity = Vector2.Lerp(_rb.velocity, speed, Time.fixedDeltaTime * 1.5f);
        }

        public virtual void Spin(Vector2 amount)
        {
            var speed = amount.x * _data.RotateSpeed + amount.y * _data.RotateSpeed;
            _rb.AddTorque(speed);
        }
    }

}
