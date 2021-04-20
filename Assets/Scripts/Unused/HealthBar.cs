using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
    }

    public void SetMaxHealth(float value)
    {
        _slider.maxValue = value;
        _slider.value = value;
    }

    public void SetHealth(float value)
    {
        _slider.value = value;
    }
    
}
