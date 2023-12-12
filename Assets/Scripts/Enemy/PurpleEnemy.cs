using Interfaces;

namespace Enemy
{
    public class PurpleEnemy : EnemyAbstract
    {
        PurpleEnemy()
        {
            MaxHealth = 300;
        }
    
        void Start()
        {
            CurrentHealth = MaxHealth;
            // waveSpawner = GetComponentInParent<WaveSpawner>();
        }
    }
}
