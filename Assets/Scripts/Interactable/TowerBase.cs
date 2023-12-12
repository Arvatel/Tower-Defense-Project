using System;
using Interfaces;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interactable
{
    // Interactable object for creating Towers during the game
    public class TowerBase : MonoBehaviour, IInteractable
    {
        [SerializeField] private string prompt = "To build tower press " + KeyCode.E;
        public string InteractionPrompt => prompt;
        public InteractableIdEnum InteractableId => InteractableIdEnum.TowerBase;
        
        
        // Tower created - for now it only simple instance
        // Later different towers will be created based on key used for creating  
        public GameObject smgTower;
        // public GameObject shotgunTower;

        private bool _isInteractable;
        public Renderer castRender;
        
        private void Start()
        {
            _isInteractable = true;
        }

        public bool Interact(PlayerObjectInteract interactor)
        {
            if (_isInteractable)
            {
                Instantiate(smgTower, gameObject.transform);
                _isInteractable = false;
                
                castRender = GetComponent<Renderer>();
                castRender.enabled = false;
                prompt = "";
            }
            return true;
        }
    }
}
