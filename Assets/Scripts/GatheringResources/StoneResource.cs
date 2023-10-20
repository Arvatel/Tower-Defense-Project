using Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace GatheringResources
{
    public class StoneResource : MonoBehaviour, IResource
    {
        [SerializeField] private int amount;
        
        public IdEnum ResourceId => IdEnum.Stone;
        public int ResourceAmount => amount;
        public bool Interact(PlayerGatherResources resource)
        {
            Debug.Log("Found stone");
            return true;
        }
    }
}
