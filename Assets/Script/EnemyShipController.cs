using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class EnemyShipController : AbstractShipController
    {
        public ObserverScriptableObject shipDestroyedNotifier;

        public int points;

        private void Update()
        {
            var transl = _data.ForwardSpeed * -1 * Time.deltaTime * transform.up;
            transform.Translate(transl);

            var curve = _data.MovementCurve.Curve;
            transl = transform.right * curve.Evaluate(Time.time) * .009f;
            transform.Translate(transl);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            shipDestroyedNotifier.Notify(gameObject);
            gameObject.SetActive(false);
        }
    }

}
