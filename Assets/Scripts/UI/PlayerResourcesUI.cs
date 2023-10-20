using TMPro;
using UnityEngine;

namespace Player
{
    // Update interface to interface in the corner - where would be shown all resources 
    public class PlayerResourcesUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI promptText;
    
        public void UpdateText(string promptMessage)
        {
            promptText.text = promptMessage;
        }
        
    }
}
