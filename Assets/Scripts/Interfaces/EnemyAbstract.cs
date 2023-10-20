using System;
using UnityEngine;

namespace Interfaces
{
    public abstract class EnemyAbstract : MonoBehaviour
    {
        //TODO: Remove it later - This Field needed for debug
        [SerializeField] private string _name = "enemy";
        
        // Fields for debugging
        [SerializeField] protected GameObject obj;
        
        protected float MaxHealth;
        protected float CurrentHealth;
        // protected HealthBar HealthBarUI;

        protected float DamageDealt;

        //TODO: Beautiful Health System for enemies
        
        void Attack(){}

        void Move(){}

        // Color changing needed mostly for Debugging
        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            Debug.Log(_name + " Took " + amount +" damage");
            var rend = obj.GetComponent<Renderer>();
            var color = Color.red;
            
            rend.material.SetColor("_Color", Color.red);
            
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log(_name + " Died");    
            }
        }
    }
}
