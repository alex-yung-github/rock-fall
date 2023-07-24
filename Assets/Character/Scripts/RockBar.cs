using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private int max;

    public void SetMaxCooldown(int count)
    {
        slider.maxValue = count;
        max = count;
        slider.value = count;

        fill.color = gradient.Evaluate(1f);
    }
    
    public void SetCooldown(int count)
    {
        slider.value = count;
        
        if(count < max)
        {
            fill.color = gradient.Evaluate(0f);
        }
        else
        {
            fill.color = gradient.Evaluate(1f);
        }
    }
}
