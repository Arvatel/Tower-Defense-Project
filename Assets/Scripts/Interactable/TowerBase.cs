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
        
        // This Bool needed in order to create only one instance of Tower on a TowerBase
        // When Tower will be destroyed _towerBuilt will be changed to "false"
        // It will allow to use this Base for creating new Tower
        // Maybe we should introduce some delay for building new Tower after previous one destroyed
        public bool towerBuilt;
        
        
        // Tower created - for now it only simple instance
        // Later different towers will be created based on key used for creating  
        public GameObject firstTower;
        
        private void Start()
        {
            towerBuilt = false;
        }

        public bool Interact(PlayerObjectInteract interactor)
        {
            if (towerBuilt)
            {
                Debug.Log("Tower already Built");    
                return false;
            }
            Debug.Log("Interacting with Tower Base");
            Instantiate(firstTower, gameObject.transform);
            prompt = String.Empty;
            towerBuilt = true;
            return true;
        }
    }
}
