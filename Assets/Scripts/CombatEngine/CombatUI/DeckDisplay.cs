using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Deck logic
//Deals cards out to hand
//Error handling -- don't use strings for errors?
//TODO: Change to have gamemanager take care of all the deck deal functions

/// <summary>
/// Handles the deck button and dealing cards to hand
/// </summary>
public class DeckDisplay : MonoBehaviour
{
    //PROG Q: How much of this really be here?
    public Button b;
    public HandHandler hand;
    GameManager manager;
    
    
    void Start() 
    {
        manager = FindObjectOfType<GameManager>();
        //Create Deck Button
        b = this.GetComponent<Button>();
        b.onClick.AddListener(manager.DrawStep);
        b.interactable = true;
    }

    /// <summary>
    /// Lets gamemanager turn on and off the button
    /// </summary>
    /// <param name="set"></param>
    public void setActive(bool set)
    {
        b.interactable = set;
    }

    /// <summary>
    /// Deals a single card, given that deck is not empty and hand is not full
    /// 
    /// Otherwise ???? currently undetermined
    /// 
    /// Should probably let gamemanager handle the logic?
    /// </summary>
    public void Deal(Card a)
    {
        bool droppable = hand.CheckIfDroppable();
        if (a != null && droppable)
        {            
            //Play some animation
            a.transform.SetParent(hand.transform);
        }
        else if (a == null)
        {
            //DESIGN Q: What to do about drawing with no cards left
        }
        else
        {
            //DESIGN Q: what to do with overdraw
            //card was drawn w/out room to drop
            //animation, add to GY or burn
        }
    }

}
