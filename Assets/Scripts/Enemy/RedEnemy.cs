using Interfaces;

namespace Enemy
{
    public class RedEnemy : EnemyAbstract
    {
        RedEnemy()
        {
            MaxHealth = 600;
        }
    
        void Start()
        {
            CurrentHealth = MaxHealth;
        }
    }
}
