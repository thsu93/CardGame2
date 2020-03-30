using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    //Card descriptors
    public string cardName;
    public GameObject nameHolder;
    public GameObject DescriptionHolder;
    public enum Slot {Attack, Magic, Defend, Any, NUM_TYPES};
    public Slot CardType = Slot.Any;

    public CardEffect playEffect;
    public CardEffect burnEffect;
    /*
    A card will have a normal play effect and a special burn effect.

    Will need to have many more values besides current above. 
    */
    public QueueCard matchingQueueCard;

    private void Start() 
    {
        nameHolder.GetComponent<Text>().text = this.cardName;
    }

}
