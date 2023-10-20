using System;
using Interfaces;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerObjectInteract : MonoBehaviour
    {
        [SerializeField] private Transform interactionPoint;
        [SerializeField] private LayerMask interactableMask;
        [SerializeField] private float interactionPointRadius = 0.5f;

        private readonly Collider[] _colliders = new Collider[3];
        [SerializeField] private int numFound;
        
        private PlayerHintUI _playerHintUI;

        private void Start()
        {
            _playerHintUI = GetComponent<PlayerHintUI>();
        }

        // Update is called once per frame
        void Update()
        {
            _playerHintUI.UpdateText(string.Empty);
            numFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, _colliders,
                interactableMask);

            if (numFound > 0)
            {
                var col = _colliders[0];
                var interactable = col.GetComponent<IInteractable>();

                _playerHintUI.UpdateText(interactable.InteractionPrompt);    
                
                if (interactable != null && Keyboard.current.eKey.wasPressedThisFrame)
                {
                    interactable.Interact(this);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
        }
    }
}
