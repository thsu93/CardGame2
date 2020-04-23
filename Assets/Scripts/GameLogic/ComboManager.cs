using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Class to handle combo checking and the UI of the combo queue
/// 
/// PROG Q: Should this be split?
/// </summary>
public class ComboManager : MonoBehaviour
{
    static int COMBOLENGTH = 3;

    Card currentAction = null;

    //some sort of dict to check against;
    //if combo is in dict, 
    /*
    public CardAction comboCheck(Card card)
    {
        check cardname + two prev card names
        if in dict, return matching card effect
        else 
        return card.playEffect;
    }
    */
    //TODO: More streamlined combo check functions

    /// <summary>
    /// 
    /// </summary>
    /// <param name="card"></param>
    /// <param name="deck"></param>
    public void addToQueue(Card card, Deck deck)
    {
        if (card != null)
        {
            card.transform.SetParent(this.transform);
            currentAction = card;
            if (this.transform.childCount > COMBOLENGTH)
            {
            //TODO: Convert to handling w/ cardIDs.
                deck.AddToGraveyard(this.transform.GetChild(0).GetComponent<Card>());
                Destroy(this.transform.GetChild(0));
            }
        }
        
    }

    public Card getAction()
    {
        Card[] cards = GetComponentsInChildren<Card>();
        string cardIDs = "";
        foreach (Card curr in cards)
        {
            cardIDs += curr.cardID;
        }
        //TODO: FIX THIS
        //return comboDict.GetComboCard(cardIDs);
        //placeholder
        return currentAction;
    }
}