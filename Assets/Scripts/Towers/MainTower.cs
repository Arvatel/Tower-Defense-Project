using UnityEngine;

namespace Towers
{
    public class MainTower : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        private float _currentHealth;
        
        // Add Health bar for Tower - attached to Tower and TO player's screen 
        // Add possibility for tower to shoot in a small radius around it
        void Start()
        {
            _currentHealth = maxHealth;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
