using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerStats : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100;
        private float _currentHealth;

        public HealthBar healthBar;
        void Start()
        {
            _currentHealth = maxHealth;
        
            healthBar.SetMaxHealth(maxHealth);
        }

        // Update is called once per frame
        void Update()
        {
            if (Keyboard.current.tKey.wasPressedThisFrame)
            {
                TakeDamage(20f);
            }
            
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                RestoreHealth(10f);
            }
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Debug.Log("Dead");
            }
            healthBar.SetCurrentHealth(_currentHealth);
        }
    
        public void RestoreHealth(float amount)
        {
            _currentHealth += amount;
            if (_currentHealth > maxHealth)
            {
                _currentHealth = maxHealth;
            }
            healthBar.SetCurrentHealth(_currentHealth);
        }
    }
}
