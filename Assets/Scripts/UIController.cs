﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//placeholder
//will need to revisit

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public UIBox UIBoxHolder;
    private UIBox newUIbox;
    public HealthBar playerHealth;
    public HealthBar enemyHealth;
    public Text TurnText;
    public DamageDisplay playerDamageDisplay;
    public DamageDisplay enemyDamageDisplay;

    void Start()
    {
    }


    public void ChangeTurn(int turn)
    {
        TurnText.text = "Turn Number: " + turn;
    }

    UIBox CreateDisplay()
    {
        newUIbox = Instantiate(UIBoxHolder, new Vector3(this.transform.position.x,this.transform.position.y,0), Quaternion.identity);
        newUIbox.transform.SetParent(this.transform.parent);
        newUIbox.transform.SetAsLastSibling();        
        return newUIbox;
    }

    public void Error(string text)
    {
        if (newUIbox!=null)
        {
            Destroy(newUIbox.gameObject);
        }
        CreateDisplay().DisplayError(text);
    }

    //Player position is 0
    //Enemy position is 1
    public void DisplayTurn(int position, int attack, int heal, int damage)
    {
        if (newUIbox!=null)
        {
            Destroy(newUIbox.gameObject);
        }
        if (position == 0)
        {
            //playerDamageDisplay.displayDamage(damage, );
        }
        if (position == 1)
        {
            //enemyDamageDisplay.displayDamage();
        }
    }

    public void GameOver()
    {
        if (newUIbox!=null)
        {
            Destroy(newUIbox.gameObject);
        }
        CreateDisplay().DisplayMessage("You Lose =(");
    }

    public void GameWin()
    {
        if (newUIbox!=null)
        {
            Destroy(newUIbox.gameObject);
        }
        CreateDisplay().DisplayMessage("You Win!");
    }

    //Pos reflects which position a character will be in
    //Pos 0 is always player
    //Pos 1 on will be enemies
    public void setMaxHP(int HP, int pos)
    {
        if (pos==0)
        {
            playerHealth.setMaxHP(HP);
        }
        else
        //needs to revisit if multi enemies
        {
            enemyHealth.setMaxHP(HP);
        }
    }

    public void setHP(int HP, int pos)
    {
        if (pos==0)
        {
            playerHealth.setHP(HP);
        }
        else
        //needs to revisit if multi enemies
        {
            enemyHealth.setHP(HP);
        }
    }
}
