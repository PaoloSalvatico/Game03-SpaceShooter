using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu(fileName = "Curve", menuName = "Space Shooter/Curve")]
    public class CurveScriptableObject : ScriptableObject
    {
        [SerializeField]
        protected AnimationCurve _curve;

        public AnimationCurve Curve
        {
            get { return _curve; }
        }
    }

}
