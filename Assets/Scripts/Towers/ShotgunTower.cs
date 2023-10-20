using System;
using Interfaces;
using UnityEngine;

namespace Towers
{
    public class ShotgunTower : TowerAbstract
    {
        public ShotgunTower()
        {
            MaxHealth = 1000;
            MaxAmmoAmount = 100;

            AmmoDamage = 100;
            ShootingRange = 5f;
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
            CurrentAmmoAmount = MaxAmmoAmount;
        }
    }
}
