using Player;
using UnityEngine;

namespace Interfaces
{
    public interface IResource
    {
        public IdEnum ResourceId { get; }

        public int ResourceAmount { get; }
        
        public bool Interact(PlayerGatherResources resource);
    }
}
