using System;
using Interfaces;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Towers
{
    public class SmgTower : TowerAbstract//, ITowerInteract
    {
        public SmgTower()
        {
            MaxAmmoAmount = 200;

            AmmoDamage = 15f;
            ShootingRange = 12f;
            RateOfFire = 2;
        }

        private void Start()
        {
            CurrentAmmoAmount = MaxAmmoAmount;
        }

        private void Update()
        {
            Shoot();
        }
    }
}
