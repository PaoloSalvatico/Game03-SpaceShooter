using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShooter.Interfaces;

namespace SpaceShooter
{
    [RequireComponent(typeof(Rigidbody2D))]
    [AddComponentMenu("")]
    public class BulletBase : MonoBehaviour, IOwnable
    {
        public float speed = 10;

        public float lifetime = 5;

        protected Rigidbody2D _rb;

        protected virtual void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        protected virtual void OnEnable()
        {
            StartCoroutine(nameof(AutoDeactivation));
        }

        protected virtual void OnDisable()
        {
            StopCoroutine("AutoDeactivation");
        }

        protected virtual IEnumerator AutoDeactivation()
        {
            yield return new WaitForEndOfFrame();
            _rb.velocity = transform.up * speed;

            yield return new WaitForSeconds(lifetime);
            gameObject.SetActive(false);
        }

        protected virtual void OnBecameInvisible()
        {
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var comp = collision.gameObject.GetComponent<EnemyHealth>();
            if (comp != null)
            {
                comp.Damage(Owner);
            }
            Owner = null;
            gameObject.SetActive(false);
        }

        public GameObject Owner { get; set; }

    }

}
