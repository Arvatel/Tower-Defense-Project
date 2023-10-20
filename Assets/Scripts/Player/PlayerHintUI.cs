using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerHintUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI promptText;
    
        public void UpdateText(string promptMessage)
        {
            promptText.text = promptMessage;
        }
    }
}
