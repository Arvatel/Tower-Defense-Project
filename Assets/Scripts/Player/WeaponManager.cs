using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    [SerializeField] private LayerMask _layerMask;
    
    public float range = 20f;
    public float damage = 20f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Debug.Log("Shoot");
            Shoot();
        }
        
    }

    void Shoot()
    {
        RaycastHit hit;

        Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range, _layerMask);
        
        EnemyAbstract enemy = hit.transform.GetComponent<EnemyAbstract>();
        if (enemy != null)
        {
            Debug.Log("Enemy Taken damage from Player");
            enemy.TakeDamage(damage);
        }
    }
}
