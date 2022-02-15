using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class LanguageManager : PersistentSingleton<LanguageManager>
    {

        public LocalizationDataScriptableObject localizationData;
        
        public void SetLocalization(LanguageKeys key)
        {
            localizationData.selectedLanguage = key;
        }
        
        public string GetLabel(string key)
        {
            return localizationData.GetLabel(key);
        }

        public string GetLabel(LabelKeys key)
        {
            return GetLabel(key.ToString());
        }

    }
}
