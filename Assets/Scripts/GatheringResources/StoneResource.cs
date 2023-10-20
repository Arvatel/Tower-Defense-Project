using Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace GatheringResources
{
    public class StoneResource : MonoBehaviour, IResource
    {
        [SerializeField] private int amount;
        private const string Name = "Stone";

        public string resourceName => Name;
        public IdEnum resourceId => IdEnum.Stone;
        public int resourceAmount => amount;
        public bool Interact(PlayerGatherResources resource)
        {
            Debug.Log("Found stone");
            return true;
        }
    }
}
