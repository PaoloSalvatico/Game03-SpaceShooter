using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SpaceShooter;

namespace SpaceShooter.Editor
{
    [CustomEditor(typeof(PlayerShipController))]
    public class PlayerShipControllerEditor : UnityEditor.Editor
    {
        PlayerShipController controller;
        private SerializedProperty _testGameObj;

        private void OnEneanle()
        {
            controller = target as PlayerShipController;    
        }
        public override void OnInspectorGUI()
        {
            _testGameObj = serializedObject.FindProperty("testGamwObject");

            serializedObject.Update();
            EditorGUILayout.PropertyField(_testGameObj);
            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.LabelField(controller.Data.ForwardSpeed.ToString());
            EditorGUILayout.LabelField(controller.Data.ForwardSpeed.ToString());

            var rb = controller.GetComponent<Rigidbody2D>();
            EditorGUILayout.LabelField("Velocity");
        }

    }
}

