using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using SpaceShooter;
using System.IO;
using System.Text;

namespace SpaceShooter.EditorUtils
{
    public static class GameObjectsUtils
    {
        [MenuItem("Space Shooter/Create Player Ship")]
        public static void CreateShip()
        {
            var go = new GameObject("PlayerShip_generated");

            var rb = go.AddComponent<Rigidbody2D>();
            rb.drag = 0.5f;

            var controller = go.AddComponent<PlayerShipController>();
            var path = "Data/PlayerShip/ShipData - Base";
            ShipDataScriptableObject data = Resources.Load<ShipDataScriptableObject>(path);
            controller.Data = data;

            go.AddComponent<PlayerMovement>();
            go.AddComponent<AbilityShoot>(); 
        }

        [MenuItem("Assets/Space Shooter/GenerateLocalizationFile", true)]
        public static bool GenerateLocalizationFile_Validation()
        {
            ////////// Fase di Lettura /////////////
            var obj = Selection.activeObject;
            //Debug.Log(AssetDatabase.GetAssetPath(obj));
            var ext = Path.GetExtension(AssetDatabase.GetAssetPath(obj));
            return ext == ".txt" || ext == ".csv";
        }

        [MenuItem("Assets/Space Shooter/GenerateLocalizationFile")]
        public static void GenerateLocalizationFile()
        {
            ///////// Lettura del file ///////////////
            var obj = Selection.activeObject;
            var readPath = AssetDatabase.GetAssetPath(obj);

            string dataAsString = File.ReadAllText(readPath);
            string[] rows = dataAsString.Split('\n');
            string[] languages = rows[0].Split('\n');
           
            ///////// Fase di Scrittura //////////////
            var folderPath = Application.dataPath + "/Script/_Generated/";
            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var writePath = folderPath + "Languages.cs";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("namespace SpaceShooter");
            sb.AppendLine("{");
            sb.AppendLine("public enum Languages");
            sb.AppendLine("{");
            sb.AppendLine("}");
            sb.AppendLine("}");

            for(int i = 1; i < languages.Length; i++)
            {
                sb.AppendLine(languages[i] + ",");
            }

            using (StreamWriter sw = File.CreateText(writePath))
            {
                sw.Write(sb.ToString());
            }

            Debug.Log("D");
            AssetDatabase.Refresh();
        }
    }
}

