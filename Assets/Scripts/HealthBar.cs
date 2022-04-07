using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Slider healthBar;
    [SerializeField] public Gradient gradient;
    [SerializeField] public Image fill;

    public void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        healthBar.value = health;
        fill.color= gradient.Evaluate(healthBar.normalizedValue);
    }
}
