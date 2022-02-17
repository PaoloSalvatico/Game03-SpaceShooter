using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SpaceShooter;

namespace SpaceShooter.Tools
{
    public class PlayerShipConfig : EditorWindow
    {
        private string _shipName = "PlayerShip";
        private float forwardSpeed = 3;
        private float sideSpeed = 3;
        private Object shipData;

        private bool hasShootAbility = true;
        private Object primaryWeaponPool;
        private Object secondaryWeaponPool;
        private ShipSize shipSize;

        [MenuItem("Space Shooter/Ship Configurator")]
        public static void OpenWindow()
        {
            var window = GetWindow<PlayerShipConfig>();
            var title = new GUIContent("Ship Configurator");
            window.titleContent = title;
            window.Show();
        }

        /// <summary>
        /// Renderizza la finestra del mio tool
        /// </summary>
        private void OnGUI()
        {
            GUILayout.Label("Prova", EditorStyles.helpBox);
            _shipName = EditorGUILayout.TextField("Ship Name", _shipName);
            forwardSpeed = EditorGUILayout.FloatField("Forward Speed", forwardSpeed);
            sideSpeed = EditorGUILayout.FloatField("Side Speed", sideSpeed);

            hasShootAbility = EditorGUILayout.Toggle("Can Shoot Weapon", hasShootAbility);

            shipSize = (ShipSize)EditorGUILayout.EnumPopup("Ship size", shipSize);
            shipData = EditorGUILayout.ObjectField("Ship Data", shipData, typeof(ShipDataScriptableObject), false);

            EditorGUILayout.BeginToggleGroup("Weapon Data", hasShootAbility);

            primaryWeaponPool = EditorGUILayout.ObjectField("Primary Weapon", primaryWeaponPool, typeof(ObjectPoolScriptableObject), false);
            secondaryWeaponPool = EditorGUILayout.ObjectField("Secondary Weapon", secondaryWeaponPool, typeof(ObjectPoolScriptableObject), false);
            EditorGUILayout.EndToggleGroup();
            if( _shipName == "")
            {
                EditorGUILayout.HelpBox("Ship has no name", MessageType.Warning);
            }
            EditorGUILayout.Space(20);
            EditorGUI.BeginDisabledGroup(_shipName == "");
            if (GUILayout.Button("Generate"))
            {
                GenerateShip();
            }
            EditorGUI.EndDisabledGroup();
        }

        private void GenerateShip()
        {
            var go = new GameObject(_shipName);

            //Player controller
            var controller = go.AddComponent<PlayerShipController>();
            controller.Data = shipData as ShipDataScriptableObject;
            go.AddComponent<PlayerMovement>();
            var collider = go.AddComponent<BoxCollider2D>();

            switch(shipSize)
            {
                case ShipSize.Small:
                case ShipSize.Regular:
                case ShipSize.Big:
                case ShipSize.Huge:
                    //var preset = Resources.Load<>
                    break;
            }
        }

    }
}

