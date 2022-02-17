using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


//[CustomEditor(typeof(Transform))]
public class TransformEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var t = target as Transform;
        //EditorGUILayout.LabelField("Position bro", t.position.ToString());

        base.DrawDefaultInspector();
        if(GUILayout.Button("Add Child"))
        {
            var go = new GameObject("Child");
            go.transform.SetParent(t);
        }
    }
}


