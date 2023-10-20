using Interfaces;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Player
{
    // TODO: Update function with other resources
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private int stoneAmount = 0;
        [SerializeField] private int moneyAmount = 0;

        public void UpdateResource(IdEnum id, int amount)
        {
            if (id == IdEnum.Money)
            {
                moneyAmount = moneyAmount + amount;
            }
            else if (id == IdEnum.Stone)
            {
                stoneAmount = stoneAmount + amount;
            }
        }

        public int GetResourceAmount(IdEnum id)
        {
            if (id == IdEnum.Money)
            {
                return moneyAmount;
            }
            else if (id == IdEnum.Stone)
            {
                return stoneAmount;
            }

            return 0;
        }
    }
}
