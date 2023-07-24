using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxCooldown(int count)
    {
        slider.maxValue = count;
        slider.value = count;
    }
    
    public void SetCooldown(int count)
    {
        slider.value = count;
    }
}
