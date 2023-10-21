using Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace GatheringResources
{
    // Items collected and can be used for healing Player
    // TODO Add cooldown
    public class HealingResource : MonoBehaviour, IResource
    {
        private int amount = 1;
        
        public IdEnum ResourceId => IdEnum.HealingItem;
        public int ResourceAmount => amount;
        public bool Interact(PlayerGatherResources resource)
        {
            Debug.Log("Found healing item");
            return true;
        }
    }
}
