using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    public Renderer custRender;
    void Start()
    {
        custRender = GetComponent<Renderer>();
        custRender.enabled = false;

    }
    
}
