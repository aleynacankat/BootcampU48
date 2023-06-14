using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider _Slider;

    public void SetMaxHealth(int health)
    {
        _Slider.maxValue = health;
        _Slider.value = health;
    } 
    
    public void SetHealth(int health)
    {
        _Slider.value = health;
    }
}
