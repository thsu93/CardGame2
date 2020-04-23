using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Intended to deal with creating, manipulating card datums given cardIDs without requiring pre-existing gameobjects
/// 
/// TODO: XML language to match full database
/// </summary>
public class CardLoader : ScriptableObject
{
    string cardfolder = "Prefabs/Cards/";

    /// <summary>
    /// Generates a card gameobject from a given cardID, given it exists within the card resources folder.
    /// 
    /// PROG Q: what to do re:errors
    /// </summary>
    /// <param name="cardID"></param>
    /// <returns></returns>
    public Card InstantiateCard(string cardID)
    {
        Card tempCard = Instantiate((Card)Resources.Load(cardfolder+cardID));
        return tempCard;
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
        return false;
    }
}
