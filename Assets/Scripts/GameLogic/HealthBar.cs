using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Health Bar UI Manager
/// </summary>
public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    int maxHealth;
    int curHealth;

    public Text charName;
    public Text healthText;
    public Gradient gradient;
    public Image fill;
    CharacterStats character;

    //PROG Q: Cleaner way to do this
    bool init = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void initialize(CharacterStats stats)
    {
        character = stats;
        setName();
        updateHP();
        init = true;
    }

    private void Update() 
    {
        if (init == true)
        {            
            if (curHealth != character.currentHP || maxHealth != character.maxHP)
            {
                updateHP();
            }
        }
    }

    // Update is called once per frame
    public void updateHP()
    {
        maxHealth = character.maxHP;
        curHealth = character.currentHP;
        healthSlider.maxValue = maxHealth; 
        healthSlider.value = curHealth;
        healthText.text = "HP: " + character.currentHP + "/" + character.maxHP; 
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }

    void setName()
    {
        charName.text = character.charName;

        // TODO: change this when getting more complex w/ names
        if (charName.text == "Player")
        {
            charName.color = Color.green;
        }

        else 
        {
            charName.color = Color.red;
        }
    }


}
