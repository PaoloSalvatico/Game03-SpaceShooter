using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SpaceShooter;
using UnityEditor.Presets;
using UnityEngine.SceneManagement;

namespace SpaceShooter.Tools
{
    public class PlayerShipConfigurator : EditorWindow
    {

        private string shipName = G.CONF_SHIP_NAME_DEFAULT;
    //    private float forwardSpeed = 3;
    //    private float sideSpeed = 3;

        private Object shipData;

        private bool hasShootAbility = true;

        private Object primaryWeaponPool;
        private Object secondaryWeaponPool;
        private ShipSize shipSize;
        
        [MenuItem("Window/Space Shooter/Ship Configurator")]
        public static void OpenWindow()
        {
            var window = GetWindow<PlayerShipConfigurator>();
            var title = new GUIContent("Ship Configurator");
            window.titleContent = title;
            window.minSize = Vector2.one * 300;
            window.position = new Rect(30, 30, 500, 500);
            window.Show();

        }

        /// <summary>
        /// Renderizza la finestra del mio tool
        /// </summary>
        private void OnGUI()
        {
            //            EditorGUILayout.LabelField("test");
            shipName = EditorGUILayout.TextField("Ship Name", shipName);
       //     forwardSpeed = EditorGUILayout.FloatField("Forward Speed", forwardSpeed);
       //     sideSpeed = EditorGUILayout.FloatField("Side Speed", sideSpeed);

            shipData = EditorGUILayout.ObjectField("Ship Data", shipData, typeof(ShipDataScriptableObject), false);

            //            hasShootAbility = EditorGUILayout.Toggle("Has Shoot Ability", hasShootAbility);

            shipSize = (ShipSize) EditorGUILayout.EnumPopup("Ship size", shipSize);

            hasShootAbility = EditorGUILayout.BeginToggleGroup("Weapon Data", hasShootAbility);
            primaryWeaponPool = EditorGUILayout.ObjectField("Primary Weapon", primaryWeaponPool, typeof(ObjectPoolScriptableObject), false);
            secondaryWeaponPool = EditorGUILayout.ObjectField("Secondary Weapon", secondaryWeaponPool, typeof(ObjectPoolScriptableObject), false);
            EditorGUILayout.EndToggleGroup();

            if(shipName == "")
            {
                EditorGUILayout.HelpBox("Ship has no name!", MessageType.Error);
            }
            else if (shipName.Length < 5)
            {
                EditorGUILayout.HelpBox("Ship name should have at least 5 characters", MessageType.Warning);
            }
            EditorGUILayout.Space(15);
            EditorGUI.BeginDisabledGroup(shipName == "");
            if (GUILayout.Button("Generate"))
            {
                GenerateShip();
            }
            EditorGUI.EndDisabledGroup();

        }

        private void GenerateShip()
        {
            var go = new GameObject(shipName);

            // Player Controller
            var controller = go.AddComponent<PlayerShipController>();
            controller.Data = shipData as ShipDataScriptableObject;
            go.AddComponent<PlayerMovement>();
            var collider = go.AddComponent<BoxCollider2D>();
            switch(shipSize)
            {
                case ShipSize.Small:
                case ShipSize.Regular:
                case ShipSize.Huge:
                case ShipSize.Big:
                    var preset = Resources.Load<Preset>(G.PRESET_REGULAR_COLLIDER);
                    preset.ApplyTo(collider);
                    break;
            }
        }
    }
}
