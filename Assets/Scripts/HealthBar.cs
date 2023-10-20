using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void SetCurrentHealth(float amount)
    {
        healthSlider.value = amount;
    }

    public void SetMaxHealth(float amount)
    {
        healthSlider.maxValue = amount;
        SetCurrentHealth(amount);
    }
}
