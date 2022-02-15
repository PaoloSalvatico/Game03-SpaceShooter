using UnityEngine;
using TMPro;

namespace SpaceShooter
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TextLoc : MonoBehaviour
    {
        private TextMeshProUGUI _label;

        public LabelKeys key;

        public string prefix;
        public string postfix;
        
        private void Start()
        {
            _label = GetComponent<TextMeshProUGUI>();
            _label.text = prefix + LanguageManager.Instance.GetLabel(key) + postfix;
        }

    }

}
