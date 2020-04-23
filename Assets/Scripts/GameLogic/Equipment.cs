using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//TODO: Ways to handle equipment upgrades. 
//TODO: Non-manual initiation of cards.  Using some database of cardID#s to generate
//TODO: Equipment passives? IE armor w/ permanent dmg reductions, poison effects to all weapons, etc.

/// <summary>
/// Handles Equipment values
/// 
/// Will need to be revisited once basics of engine are handled
/// </summary>
public class Equipment: MonoBehaviour
{
    public EquipmentHandler.EquipmentTypes type;
    public Card[] AssociatedCards; 


    private void Start() 
    {
        AssociatedCards = null;
        type = EquipmentHandler.EquipmentTypes.Arm;
    }
}