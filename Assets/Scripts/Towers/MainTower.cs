using UnityEngine;

namespace Towers
{
    public class MainTower : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100;
        private float _currentHealth;
        public HealthBar healthBar;
        
        [SerializeField] private string prompt = "";
        
        // Add Health bar for Tower - attached to Tower and TO player's screen 
        // Add possibility for tower to shoot in a small radius around it
        void Start()
        {
            _currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }
        
        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Debug.Log("Game Over");
            }
            healthBar.SetCurrentHealth(_currentHealth);
        }
    }
}
