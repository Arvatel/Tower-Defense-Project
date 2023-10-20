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

    void Update()
    {
        // For Debugging
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            TakeDamage(10);
        }
    }
}
