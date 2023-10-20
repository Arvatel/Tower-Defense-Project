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

        // Update is called once per frame
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
            
                _playerResourcesUI.UpdateText(interactable.resourceId.ToString());    
            
                if (interactable != null)
                {
                    interactable.Interact(this);
                    
                    // if object is Health Kit it restores Health
                    if (interactable.resourceId == IdEnum.Health)
                    {
                        _stats.RestoreHealth(interactable.resourceAmount);
                    }

                    // For gathering general resources
                    else
                    {
                        _inventory.UpdateResource(interactable.resourceId, interactable.resourceAmount);
                        Debug.Log(interactable.resourceId + ": " + _inventory.GetResourceAmount(interactable.resourceId));
                
                        _playerResourcesUI.UpdateText(IdEnum.Money + ": " + _inventory.GetResourceAmount(IdEnum.Money) + "\n" +
                                                      IdEnum.Stone + ": " + _inventory.GetResourceAmount(IdEnum.Stone)) ;
                    }
                    Destroy(col.gameObject);
                }
            }
            if (Keyboard.current.fKey.wasPressedThisFrame)
            {
                _inventory.UpdateResource(IdEnum.Money, 10);
                Debug.Log("Money: " + _inventory.GetResourceAmount(IdEnum.Money));
            }
        }
    
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(gatheringPoint.position, gatheringPointRadius);
        }
    }
}
