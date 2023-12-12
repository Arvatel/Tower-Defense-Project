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
        
        // Color changing needed mostly for Debugging
        public void TakeDamage(float amount)
        {
            CurrentHealth -= amount;
            Debug.Log(_name + " Took " + amount +" damage");
            
            // for Debug
            // var rend = obj.GetComponent<Renderer>();
            // var color = Color.red;
            
            // rend.material.SetColor("_Color", Color.red);
            
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log(_name + " Died");    
            }
        }

        public void EnemyDead()
        {
            Destroy(gameObject);
            Debug.Log(_name + " Died"); 
        }
    }
}
