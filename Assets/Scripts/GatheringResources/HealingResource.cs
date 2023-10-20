using Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace GatheringResources
{
    public class HealingResource : MonoBehaviour, IResource
    {
        [SerializeField] private int amount;
        
        public IdEnum ResourceId => IdEnum.Health;
        public int ResourceAmount => amount;
        public bool Interact(PlayerGatherResources resource)
        {
            Debug.Log("Found healing item");
            return true;
        }
    }
}
