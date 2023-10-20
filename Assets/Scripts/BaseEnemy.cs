using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseEnemy : EnemyAbstract
{
    BaseEnemy()
    {
        MaxHealth = 200;
    }
    
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            TakeDamage(10);
        }
        
        
    }
}
