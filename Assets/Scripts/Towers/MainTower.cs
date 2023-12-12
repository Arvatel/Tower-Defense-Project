using System;
using Interfaces;
using UnityEngine;

namespace Towers
{
    public class MainTower : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100;
        private float _currentHealth;
        public HealthBar healthBar;
        
        
        [SerializeField] protected Transform centralPoint;
        [SerializeField] protected LayerMask enemyMask;
        
        private readonly Collider[] _colliders = new Collider[3];
        [SerializeField] private int numFound;
        private float size = 3.5f;
        
        
        // Add Health bar for Tower - attached to Tower and TO player's screen 
        // Add possibility for tower to shoot in a small radius around it
        void Start()
        {
            _currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private void Update()
        {
            numFound = Physics.OverlapSphereNonAlloc(centralPoint.position, size, _colliders, enemyMask);
            
            if (numFound > 0)
            {
                Debug.Log("Enemy Detected");
                var col = _colliders[0];
                var enemy = col.GetComponent<EnemyAbstract>();

                if (enemy != null)
                {
                    Debug.Log("Enemy not null");
                    TakeDamage(20);
                    enemy.EnemyDead();
                }
            }
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
        
        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.green;
        //     Gizmos.DrawWireSphere(centralPoint.position, size);
        // }
    }
}
