using Player;
using UnityEngine;

namespace Interfaces
{
    public interface IInteractable
    {
        //Message displayed to player when looking at interactable object
        public string InteractionPrompt { get; }

        public bool Interact(PlayerObjectInteract interactor);
    }
}
