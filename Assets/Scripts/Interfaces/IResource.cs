using Player;
using UnityEngine;

namespace Interfaces
{
    public interface IResource
    {
        public IdEnum resourceId { get; }

        public int resourceAmount { get; }
        
        public bool Interact(PlayerGatherResources resource);
    }
}
