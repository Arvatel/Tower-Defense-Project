using Interfaces;
using Player;
using UnityEngine;

namespace Interactable
{
    // Class only for testing purposes
    public class InteractSphere : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _prompt = "To interact press E";
        public GameObject FirstTower;

        public InteractableIdEnum InteractableId => InteractableIdEnum.Other;
        public string InteractionPrompt => _prompt;
        public bool Interact(PlayerObjectInteract interactor)
        {
            Debug.Log("Interacting with Sphere");
            Instantiate(FirstTower, gameObject.transform);
            return true;
        }
    }
}
