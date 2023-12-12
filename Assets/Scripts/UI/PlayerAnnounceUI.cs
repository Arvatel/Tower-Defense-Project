using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerAnnounceUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI promptText;
    
        public void UpdateText(string promptMessage)
        {
            promptText.text = promptMessage;
        }
    }
}
