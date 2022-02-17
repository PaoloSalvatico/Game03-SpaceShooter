using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class GameBounds : MonoBehaviour
    {
        public Transform top;
        public Transform bottom;
        public Transform right;
        public Transform left;

        private void Start()
        {
            var cam = Camera.main;
            var screenSize = cam.ViewportToWorldPoint(Vector2.one);
            var screenWidth = screenSize.x;
            var screenHeight = screenSize.y;

            right.position = new Vector3(screenWidth, 0, 0);
            left.position = new Vector3(-screenWidth, 0, 0);
            top.position = new Vector3(0, screenHeight, 0);
            bottom.position = new Vector3(0, -screenHeight, 0);
        }

    }
    
}
