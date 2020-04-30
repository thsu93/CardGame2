using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Intended to deal with creating, manipulating card datums given cardIDs without requiring pre-existing gameobjects
/// 
/// Currently also handles checking if a card exists. Should this be forked off to a different class?
/// 
/// TODO: Decide where to check if card exists. 
/// TODO: XML language to match full database?
/// PROG Q: Resources.Load is expensive, better way to do this? Just have an array with every card loaded in? Then how to sort? sort for combo?
/// </summary>
public class CardLoader : ScriptableObject
{
    string cardfolder = "Prefabs/Cards/";



    /// <summary>
    /// Generates a card gameobject from a given cardID, given it exists within the card resources folder.
    /// 
    /// PROG Q: what to do re:errors. Currently does not handle, assumes good input.
    /// </summary>
    /// <param name="cardID"></param>
    /// <returns></returns>
    public Card InstantiateCard(string cardID)
    {
        Card card = Instantiate(Resources.Load<Card>(cardfolder+cardID));
        return card;
    }

    /// <summary>
    /// Checks if a given cardID exists in the pool.
    /// 
    /// Currently not used, will use once databases established.
    /// </summary>
    /// <param name="cardID"></param>
    /// <returns></returns>
    public bool exists(string cardID)
    {
        if (cardID == "000001000002000003")
        {
            return true;
        }
        return false;
    }
}
