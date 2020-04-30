using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//TO DO:
//Where to use text fields vs drawn on image
//Use slots to describe cards? Currently unused, due to card-effects

public class Card : MonoBehaviour
{
    //Internal card descriptors
    public string cardID;
    //Visual reference placeholders 
    //TO DO: re-evaluate for a drawn image
    public string cardName;
    public GameObject nameHolder;
    public GameObject DescriptionHolder;

    //perhaps unnecessary
    public enum Slot {Attack, Magic, Defend, Any, NUM_TYPES};
    public Slot CardType = Slot.Any;

    public CardAction play;
    public CardAction burn;

    private void Start()
    {
        nameHolder.GetComponent<Text>().text = this.cardName;
    }

}
