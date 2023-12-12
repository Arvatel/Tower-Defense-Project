using Interfaces;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Player
{
    // TODO: Update function with other resources
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Resources")]
        [SerializeField] private int stone = 0;
        [SerializeField] private int money = 0;

        [Header("Player's Consumables")]
        [SerializeField] private int shotgunAmmo = 0;
        [SerializeField] private int smgAmmo = 0;
        [SerializeField] private int healingItem = 0;
        
        [Header("Consumables towers")]
        [SerializeField] private int towerAmmoPack = 0;

        public void UpdateResource(IdEnum id, int amount)
        {
            if (id == IdEnum.Money)
            {
                money += amount;
            }
            else if (id == IdEnum.Stone)
            {
                stone += amount;
            }
            else if (id == IdEnum.ShotgunAmmo)
            {
                shotgunAmmo += amount;
            }
            else if (id == IdEnum.SmgAmmo)
            {
                smgAmmo += amount;
            }
            else if (id == IdEnum.HealingItem)
            {
	            healingItem += amount;
            }

            else if (id == IdEnum.TowerAmmoPack)
            {
	            towerAmmoPack += amount;
            }
        }

        public int GetResourceAmount(IdEnum id)
        {
            if (id == IdEnum.Money)
            {
                return money;
            }
            else if (id == IdEnum.Stone)
            {
                return stone;
            }
            else if (id == IdEnum.ShotgunAmmo)
            {
                return shotgunAmmo;
            }
            else if (id == IdEnum.SmgAmmo)
            {
                return smgAmmo;
            }
            else if (id == IdEnum.HealingItem)
            {
                return healingItem;
            }
            else if (id == IdEnum.TowerAmmoPack)
            {
                return towerAmmoPack;
            }

            return 0;
        }
    }
}
