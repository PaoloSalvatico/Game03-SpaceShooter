using UnityEditor;
using SpaceShooter;
using UnityEngine;

namespace SpaceShooter.Editor
{
    [CustomEditor(typeof(PlayerShipController))]
    public class PlayerShipControllerEditor : UnityEditor.Editor
    {
        PlayerShipController controller;

        private SerializedProperty _testGameObject;


        private void OnEnable()
        {
            controller = target as PlayerShipController;    
        }

        public override void OnInspectorGUI()
        {
            _testGameObject = serializedObject.FindProperty("testGameObject");

            serializedObject.Update();
            EditorGUILayout.PropertyField(_testGameObject);
            serializedObject.ApplyModifiedProperties();

            //base.DrawDefaultInspector();
            //            base.OnInspectorGUI();
            EditorGUILayout.LabelField($"Forward Speed: {controller.Data.ForwardSpeed}");
            EditorGUILayout.LabelField($"Side Speed: {controller.Data.SideSpeed}");

            var rb = controller.GetComponent<Rigidbody2D>();
            EditorGUILayout.LabelField($"Velocity Magnitude: {rb.velocity.magnitude}");
        }
    }

}
