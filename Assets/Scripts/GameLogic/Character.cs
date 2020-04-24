using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains a character's equipment, decklist, and stats
/// </summary>
public class Character : MonoBehaviour
{
    public List<Equipment> equips;

    /// <summary>
    /// Decklist generated from the equipment list
    /// 
    /// TODO: Likely should switch to list of cardID strings, depending on Deck
    /// </summary>
    public List<string> decklist;
    
    public CharacterStats stats;

    private void Awake() {
        decklist = new List<string>();
        foreach (Equipment equip in equips)
        {
            foreach (Card tempCard in equip.AssociatedCards)
            {
                decklist.Add(tempCard.cardID);
            }
        }
    }
}