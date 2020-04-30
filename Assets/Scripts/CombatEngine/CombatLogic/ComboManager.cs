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
    Card currentAction = null;

    CardLoader loader;

    private void Start() 
    {
        loader = ScriptableObject.CreateInstance<CardLoader>();
    }

    /// <summary>
    /// Adds the given card to queue.
    /// </summary>
    /// <param name="card"></param>
    /// <param name="deck"></param>
    public void addToQueue(Card card)
    {
        if (card != null)
        {
            card.transform.SetParent(this.transform);
            currentAction = card;
        }
    }
    

    /// <summary>
    /// Checks if the cards in the combo queue match a combo card
    /// 
    /// TODO: Should this be checking if 3 cards? Or is that handled adequately already
    /// </summary>
    /// <returns></returns>
    public Card checkForCombo()
    {
        Card[] cards = GetComponentsInChildren<Card>();
        string cardIDs = "";
        foreach (Card curr in cards)
        {
            cardIDs += curr.cardID;
        }
        if (loader.exists(cardIDs))
        {
            Debug.Log("Combo");
            return loader.InstantiateCard(cardIDs);
        }
        else
            return currentAction;
    }

    /// <summary>
    /// Gets the first card in the combo queue
    /// 
    /// Currently used to clear in the clean-up phase 
    /// </summary>
    /// <returns>first child of combo queue</returns>
    public Card getFirst()
    {
        return this.transform.GetChild(0).GetComponent<Card>();
    }

    public void Reset()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}