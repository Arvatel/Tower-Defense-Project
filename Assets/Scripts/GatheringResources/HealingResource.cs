using Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace GatheringResources
{
    public class HealingResource : MonoBehaviour, IResource
    {
        [SerializeField] private int amount;
        private const string Name = "Heal";

        public string resourceName => Name;
        public IdEnum resourceId => IdEnum.Health;
        public int resourceAmount => amount;
        public bool Interact(PlayerGatherResources resource)
        {
            Debug.Log("Found healing item");
            return true;
        }
    }
}
