using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public int maxHealth;
    public Text charName;
    public Text healthText;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setMaxHP(int max)
    {
        maxHealth = max;
        healthSlider.maxValue = max;
        healthSlider.value = maxHealth;
        fill.color = gradient.Evaluate(1f);
    }

    // Update is called once per frame
    public void setHP(int health)
    {
        
        healthSlider.value = health;
        healthText.text = "HP: " + health + "/" + maxHealth; 
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    public void setName(string name, Color color)
    {
        charName.text = name;
        charName.color = color;
    }


}
