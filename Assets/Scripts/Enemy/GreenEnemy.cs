using Interfaces;

namespace Enemy
{
    public class GreenEnemy : EnemyAbstract
    {
        GreenEnemy()
        {
            MaxHealth = 200;
        }
    
        void Start()
        {
            CurrentHealth = MaxHealth;
        }
    }
}
