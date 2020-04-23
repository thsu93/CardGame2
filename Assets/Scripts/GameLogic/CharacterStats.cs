using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds all a character's relevant stats
/// 
/// Currently: Name, Level, HP, Current+Max HP
/// </summary>
public class CharacterStats : MonoBehaviour
{

    public string charName = "New Character";
    public int charLevel=1;

    //TODO: more stats as needed obviously

    //DESIGN Q: Should there be non-HP stats or completely tied to cards

    //PROG Q: Should HP be managed on its own? Should this be private?
    public int currentHP=1;
    public int maxHP=1;

    //PROG Q: does this need to be called this aggressively?
    private void Update() {
        correctHP();
    }

    /// <summary>
    /// Initialize a character's stats. Will set current HP to max HP.
    /// </summary>
    /// <param name="name">Char name</param>
    /// <param name="level">Char's level</param>
    /// <param name="MaxHP">Maximum HP</param>
    public void intializeFull(string name, int level=1, int MaxHP=1)
    {
        charName = name;
        charLevel = level;
        initializeHP(MaxHP);
    }

    //TODO: Likely can be made w/out its own function, re-evaluate once stats grow more complex
    private void initializeHP(int HP)
    {
        maxHP = HP;
        currentHP = maxHP;
    }

    public void setMaxHP(int HP)
    {
        maxHP = HP;
    }

    public void setCurrentHP(int HP)
    {
        currentHP = HP;
    }

    /// <summary>
    /// Subtracts damage from current HP
    /// 
    /// Give negative number to heal
    /// </summary>
    /// <param name="damage"></param>
    public void changeHP(int damage)
    {
        currentHP -= damage;
    }

    /// <summary>
    /// Updates HP within bounds 0-Max HP
    /// </summary>
    private void correctHP()
    {
        if (currentHP>maxHP)
        {
            currentHP = maxHP;
        }
        if (currentHP<0)
        {
            currentHP = 0;
        }
    }


}