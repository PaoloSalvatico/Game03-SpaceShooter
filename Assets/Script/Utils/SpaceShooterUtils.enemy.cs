using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.Presets;

namespace SpaceShooter.EditorUtils
{
    public partial class SpaceShooterUtils
    {
        [MenuItem("Assets/Space Shooter/Generate Enemy Data", true)]
        public static bool GenerateEnemyData_Validation()
        {
            var obj = Selection.activeObject;
            var ext = Path.GetExtension(AssetDatabase.GetAssetPath(obj));
            return ext == ".txt" || ext == ".csv";
        }

        [MenuItem("Assets/Space Shooter/Generate Enemy Data")]
        public static void GenerateEnemyData()
        {
            var generatedFilesFolder = $"{Application.dataPath}/{G.GENERATED_ENEMY_DATA_FOLDER}";
            if (!Directory.Exists(generatedFilesFolder))
            {
                Directory.CreateDirectory(generatedFilesFolder);
            }
            else
            {
                var di = new DirectoryInfo(generatedFilesFolder);
                foreach (var file in di.GetFiles())
                {
                    file.Delete(); 
                }
                // foreach (var dir in di.GetDirectories())
                // {
                //    dir.Delete(true); 
                // }
            }
            // Lettura del file
            var obj = Selection.activeObject;
            var readPath = AssetDatabase.GetAssetPath(obj);

            var dataAsString = File.ReadAllText(readPath);
            var rows = dataAsString.Split('\n');

            for(var i = 1; i < rows.Length; i++)
            {
                var d = rows[i].Trim().Split(',');

                var so = ScriptableObject.CreateInstance<ShipDataScriptableObject>();
                so.ForwardSpeed = float.Parse(d[1]);
                so.SideSpeed = float.Parse(d[2]);
                var weaponPool = Resources.Load<ObjectPoolScriptableObject>($"{G.WEAPONS_FOLDER}{d[3]}");
                so.PrimaryWeaponPool = weaponPool;
                //var movementCurve = Resources.Load<AnimationCurve>()
                AssetDatabase.CreateAsset(so, $"{G.ASSETS_FOLDER}{G.GENERATED_ENEMY_DATA_FOLDER}{G.GENERATED_ENEMY_FILE_PREFIX} - {d[0]}.asset");
                AssetDatabase.SaveAssets();

                CreateEnemyShipPrefabFromData(so);
            }
            AssetDatabase.Refresh();

        }

        public static void CreateEnemyShipPrefabFromData(ShipDataScriptableObject data)
        {
            var go = new GameObject("Enemy Ship - Generated");
            var controller = go.AddComponent<EnemyShipController>();
            controller.Data = Selection.activeObject as ShipDataScriptableObject;
            go.AddComponent<AbilityShoot>();
            go.AddComponent<SpriteRenderer>();
            var collider = go.AddComponent<BoxCollider2D>();
            Preset colliderPreset = Resources.Load<Preset>("ShipPresets/ShipColliderRegular");
            colliderPreset.ApplyTo(collider);

            PrefabUtility.SaveAsPrefabAsset(go, $"Assets/Prefab/{data.name}.prefab");
            AssetDatabase.Refresh();
        }

        [MenuItem("GameObject/Space Shooter/Create Enemy Ship")]
        public static void CreateEnemyShip()
        {
            var go = new GameObject("Enemy Ship - Generated");
            go.AddComponent<EnemyShipController>();
            go.AddComponent<AbilityShoot>();
            go.AddComponent<SpriteRenderer>();
            var collider = go.AddComponent<BoxCollider2D>();
            Preset colliderPreset = Resources.Load<Preset>("ShipPresets/ShipColliderRegular");
            colliderPreset.ApplyTo(collider);

            Selection.activeObject = go;
        }

        [MenuItem("Assets/Space Shooter/Create Enemy Ship", true)]
        public static bool CreateEnemyShipFromData_Validation()
        {
            return Selection.activeObject is ShipDataScriptableObject;
        }

        [MenuItem("Assets/Space Shooter/Create Enemy Ship")]
        public static void CreateEnemyShipFromData()
        {
            var go = new GameObject("Enemy Ship - Generated");
            var controller = go.AddComponent<EnemyShipController>();
            controller.Data = Selection.activeObject as ShipDataScriptableObject;
            go.AddComponent<AbilityShoot>();
            go.AddComponent<SpriteRenderer>();
            var collider = go.AddComponent<BoxCollider2D>();
            Preset colliderPreset = Resources.Load<Preset>("ShipPresets/ShipColliderRegular");
            colliderPreset.ApplyTo(collider);

            PrefabUtility.SaveAsPrefabAsset(go, $"Assets/Prefab/{Selection.activeObject}.prefab");
            AssetDatabase.Refresh();
        }
    }
}
