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
        
        protected int MaxAmmoAmount;
        protected int CurrentAmmoAmount;

        protected float AmmoDamage;
        protected float RateOfFire; 
        protected float ShootingRange;
        protected float Time = 0;
        
        // Method for detecting enemies and shooting them
        // Most likely shooting will cause to damage to random or closest to the base Enemy withing range
        // We do not need to materialise the bullets in order to simplify system and reduce system load
        
        // TODO: Separate function into 2 - actual shoot and detecting enemies (if needed)
        protected void Shoot()
        {
            numFound = Physics.OverlapSphereNonAlloc(shootingPoint.position, ShootingRange, _colliders,
                enemyMask);
            
            Time += UnityEngine.Time.deltaTime;
            float nextShoot = 1 / RateOfFire;

            if (numFound > 0)
            {
                var col = _colliders[0];
                var enemy = col.GetComponent<EnemyAbstract>();

                if (enemy != null)
                {
                    // Debug.Log("Found enemy");
                    if (Time >= nextShoot)
                    {
                        CurrentAmmoAmount -= 1;
                        enemy.TakeDamage(AmmoDamage);
                        Time = 0;
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
        
        // Function used for Debug purposes
        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.green;
        //     Gizmos.DrawWireSphere(shootingPoint.position, ShootingRange);
        // }
    }
}
