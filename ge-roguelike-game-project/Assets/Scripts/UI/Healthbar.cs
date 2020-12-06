using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Text currentHPText;
    public Text maxHPText;

    public void SetMaxHealth(int health)
    {
        
        slider.maxValue = health;
        slider.value = health;
        SetCurrentHealthText(health);
        SetMaxHealthText(health);
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        SetCurrentHealthText(health);
    }

    public void SetCurrentHealthText(int currentHealth)
    {
        currentHPText.text = currentHealth + " /";
        Debug.Log(currentHealth);
    }

    public void SetMaxHealthText(int maxHealth)
    {
        maxHPText.text = maxHealth.ToString();
    }
}
