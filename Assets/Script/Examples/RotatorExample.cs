using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class RotatorExample : MonoBehaviour
    {
        public float rotationSpeed = 1;
        void Update()
        {
            transform.Rotate(transform.forward, rotationSpeed);
        }
    }
}
