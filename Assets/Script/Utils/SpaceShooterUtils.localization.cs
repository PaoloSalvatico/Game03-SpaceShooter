using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEditor;

namespace SpaceShooter.EditorUtils
{
    public static partial class SpaceShooterUtils
    {
        [MenuItem("Assets/Space Shooter/Generate Localization Files", true)]
        public static bool GenerateLocalizationFiles_Validation()
        {
            var obj = Selection.activeObject;
            var ext = Path.GetExtension(AssetDatabase.GetAssetPath(obj));
            return ext == ".txt" || ext == ".csv";
        }

        [MenuItem("Assets/Space Shooter/Generate Localization Files")]
        public static void GenerateLocalizationFiles()
        {
            // Lettura del file
            var obj = Selection.activeObject;
            var readPath = AssetDatabase.GetAssetPath(obj);

            var dataAsString = File.ReadAllText(readPath);
            var rows = dataAsString.Split('\n');
            var langs = rows[0].Split(',');

            // Fase di scrittura
            var generatedFilesFolder = Application.dataPath + G.GENERATED_FILES_FOLDER;
            if (!Directory.Exists(generatedFilesFolder))
            {
                Directory.CreateDirectory(generatedFilesFolder);
            }

            GenerateLanguageKeysEnum(langs, generatedFilesFolder);
            GenerateLabelKeysEnum(rows, generatedFilesFolder);

            AssetDatabase.Refresh();
        }

        private static void GenerateLanguageKeysEnum(string[] langs, string folder)
        {
            var writePath = folder + G.LANGUAGE_KEYS_CLASSNAME + ".cs";

            var sb = new StringBuilder();
            sb.AppendLine(G.SPACESHOOTER_NAMESPACE);
            sb.AppendLine("{");
            sb.AppendLine(
                $"\tpublic enum {G.LANGUAGE_KEYS_CLASSNAME}"); // Uso l'interpolazione di stringa per comporre la riga
            sb.AppendLine("\t{");
            for (var i = 1; i < langs.Length; i++)
            {
                sb.AppendLine($"\t\t{langs[i]},");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");

            using var sw = File.CreateText(writePath);
            sw.Write(sb.ToString());
        }

        private static void GenerateLabelKeysEnum(string[] rows, string folder)
        {
            var writePath = folder + G.LABEL_KEYS_CLASSNAME + ".cs";

            var sb = new StringBuilder();
            sb.AppendLine(G.SPACESHOOTER_NAMESPACE);
            sb.AppendLine("{");
            sb.AppendLine(
                $"\tpublic enum {G.LABEL_KEYS_CLASSNAME}"); // Uso l'interpolazione di stringa per comporre la riga
            sb.AppendLine("\t{");
            for (var i = 1; i < rows.Length; i++)
            {
                var val = rows[i].Split(',')[0];
                sb.AppendLine($"\t\t{val},");
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");


            using var sw = File.CreateText(writePath);
            sw.Write(sb.ToString());
        }
    }
}