using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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