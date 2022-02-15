using UnityEngine;
using UnityEditor;

namespace SpaceShooter.EditorUtils
{
    public static partial class SpaceShooterUtils
    {
        [MenuItem("GameObject/Space Shooter/Create Player Ship")]
        public static void CreateShip()
        {
            var go = new GameObject("Player Ship - Generated");

            var rb = go.AddComponent<Rigidbody2D>();
            rb.drag = 0.5f;

            var controller = go.AddComponent<PlayerShipController>();
            const string path = "Data/ShipData - Base";
            var data = Resources.Load<ShipDataScriptableObject>(path);
            controller.Data = data;
            go.AddComponent<PlayerMovement>();
            go.AddComponent<AbilityShoot>();
        }
    }
}
