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
            MaxHealth = 1000;
            MaxAmmoAmount = 200;

            AmmoDamage = 50;
            ShootingRange = 15f;
            RateOfFire = 2;
        }

        private void Start()
        {
            CurrentHealth = MaxHealth;
            CurrentAmmoAmount = MaxAmmoAmount;
        }

        private void Update()
        {
            Shoot();
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                ReplenishAmmo(10);
            }
        }

        // TODO: think about it
        // public string InteractionPrompt { get; }
        // public bool Interact(PlayerObjectInteract interactor)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
