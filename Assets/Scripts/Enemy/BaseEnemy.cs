using Interfaces;

namespace Enemy
{
    public class BaseEnemy : EnemyAbstract
    {
        BaseEnemy()
        {
            MaxHealth = 200;
        }
    
        void Start()
        {
            CurrentHealth = MaxHealth;
        }

        void Update()
        {
        }
    }
}
