using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerGatherResources : MonoBehaviour
    {
        [SerializeField] private Transform gatheringPoint;
        [SerializeField] private LayerMask gatheringMask;
        [SerializeField] private float gatheringPointRadius = 2f;

        // Understand why there are used only 3 elements, fix if needed
        private readonly Collider[] _colliders = new Collider[3];
        [SerializeField] private int numFound;
    
        private PlayerResourcesUI _playerResourcesUI;

        private PlayerInventory _inventory;
        private PlayerStats _stats;

        private void Start()
        {
            _playerResourcesUI = GetComponent<PlayerResourcesUI>();
            _inventory = GetComponent<PlayerInventory>();
            _stats = GetComponent<PlayerStats>();
        }

        // TODO: Reorganize the function to be more concise and structured
        void Update()
        {
            _playerResourcesUI.UpdateText(IdEnum.Money + ": " + _inventory.GetResourceAmount(IdEnum.Money) + "\n" +
                                          IdEnum.Stone + ": " + _inventory.GetResourceAmount(IdEnum.Stone));
            numFound = Physics.OverlapSphereNonAlloc(gatheringPoint.position, gatheringPointRadius, _colliders,
                gatheringMask);

            if (numFound > 0)
            {
                var col = _colliders[0];
                var interactable = col.GetComponent<IResource>();
            
                _playerResourcesUI.UpdateText(interactable.ResourceId.ToString());    
            
                if (interactable != null)
                {
                    interactable.Interact(this);
                    
                    // For gathering general resources
                    _inventory.UpdateResource(interactable.ResourceId, interactable.ResourceAmount);
                    Debug.Log(interactable.ResourceId + ": " + _inventory.GetResourceAmount(interactable.ResourceId));
                
                    _playerResourcesUI.UpdateText(IdEnum.Money + ": " + _inventory.GetResourceAmount(IdEnum.Money) + "\n" +
                                                      IdEnum.Stone + ": " + _inventory.GetResourceAmount(IdEnum.Stone)) ;
                    
                    Destroy(col.gameObject);
                }
            }
            
            // Condition used for Debug purposes
            if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                _inventory.UpdateResource(IdEnum.Money, 10);
                Debug.Log("Money: " + _inventory.GetResourceAmount(IdEnum.Money));
            }
        }
    
        // Function used for Debug purposes
        // private void OnDrawGizmos()
        // {
        //     Gizmos.color = Color.yellow;
        //     Gizmos.DrawWireSphere(gatheringPoint.position, gatheringPointRadius);
        // }
    }
}
