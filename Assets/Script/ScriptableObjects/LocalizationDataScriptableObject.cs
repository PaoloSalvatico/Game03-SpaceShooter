using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace  SpaceShooter
{
    [CreateAssetMenu(fileName = "LocalizationData", menuName = "Space Shooter/Localization Data")]
    public class LocalizationDataScriptableObject : ScriptableObject
    {
        public TextAsset rawData;

        private string _data;

        private DataTable _table;

        public LanguageKeys selectedLanguage;
        
        public void Init()
        {
            _data = rawData.text;

            var rows = _data.Split('\n');
            var langs = rows[0].Trim().Split(',');
            
            // Crea la tabella
            _table = new DataTable();
            
            for (var i = 0; i < langs.Length; i++)
            {
                var colName = langs[i];
                var dataColumn = _table.Columns.Add(colName, typeof(string));
                if (i != 0) continue;
                
                // Setta la prima colonna (id) come 'primary'
                var primaryKeyColumns = new DataColumn[1];
                primaryKeyColumns[0] = dataColumn;
                _table.PrimaryKey = primaryKeyColumns;
            }
            for (var i = 1; i < rows.Length; i++)
            {
                object[] row = rows[i].Trim().Split(',');
                _table.Rows.Add(row);
            }
        }

        public string GetLabel(string key)
        {
            if(_table == null) Init();
            
            if (!_table.Rows.Contains(key)) return "";
            var dataRow = _table.Rows.Find(key);
            return dataRow[selectedLanguage.ToString()].ToString();
        }
    }
}
