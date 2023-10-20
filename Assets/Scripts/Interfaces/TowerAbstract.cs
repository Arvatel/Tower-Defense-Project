using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

namespace Interfaces
{
    // Base class for Towers
    public abstract class TowerAbstract : MonoBehaviour
    {
        [SerializeField] protected Transform shootingPoint;
        [SerializeField] protected LayerMask enemyMask;
        
        private readonly Collider[] _colliders = new Collider[3];
        [SerializeField] private int numFound;
        
        protected float MaxHealth;
        protected float CurrentHealth;
        protected HealthBar HealthBarUI;
        
        protected int MaxAmmoAmount;
        protected int CurrentAmmoAmount;

        protected float AmmoDamage;
        protected float RateOfFire; 
        protected float ShootingRange;
        protected float time = 0;

        //TODO: Health System for towers
        
        // Method for detecting enemies and shooting them
        // Most likely shooting will cause to damage to random or closest to the base Enemy withing range
        // We do not need to materialise the bullets in order to simplify system and reduce system load
        protected void Shoot()
        {
            numFound = Physics.OverlapSphereNonAlloc(shootingPoint.position, ShootingRange, _colliders,
                enemyMask);
            
            time += Time.deltaTime;
            float nextShoot = 1 / RateOfFire;

            if (numFound > 0)
            {
                var col = _colliders[0];
                var enemy = col.GetComponent<EnemyAbstract>();

                if (enemy != null)
                {
                    // Debug.Log("Found enemy");
                    if (time >= nextShoot)
                    {
                        CurrentAmmoAmount -= 1;
                        enemy.TakeDamage(AmmoDamage);
                        time = 0;
                        Debug.Log("Ammo " + CurrentAmmoAmount);
                    }
                }
            }
        }

        // protected GameObject EnemyDetector() {}
        
        protected void ReplenishAmmo(int amount)
        {
            CurrentAmmoAmount += amount;
            if (CurrentAmmoAmount > MaxAmmoAmount)
                CurrentAmmoAmount = MaxAmmoAmount;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(shootingPoint.position, ShootingRange);
        }
    }
}
