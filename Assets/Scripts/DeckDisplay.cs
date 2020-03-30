using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Deck logic
//Deals cards out to hand
//Error handling -- don't use strings for errors?

public class DeckDisplay : MonoBehaviour
{
    //should this really be here?
    public Button b;
    public GameObject PlayerHand;
    GameManager manager;
    DropZone handDrop;
    HandHandler hand;
    Character associatedCharacter;
    
    void Start() 
    {
        //Create Deck Button
        b = this.GetComponent<Button>();
        b.onClick.AddListener(FullDeal);
        GameObject ManagerHolder = GameObject.Find("GameManager");
        manager = ManagerHolder.GetComponent<GameManager>();
        handDrop = PlayerHand.GetComponent<DropZone>();
        hand = PlayerHand.GetComponent<HandHandler>();
    }

    public void InitializeDeck(Character character)
    {
        associatedCharacter = character;
    }

    void FullDeal()
    {
        bool droppable = true;
        while (droppable)
        {
            Card a = associatedCharacter.GenerateNewCard();
            droppable = hand.CheckIfDroppable(a);
            if (droppable)
            {
                Deal(a);
            }
        }
        b.interactable = false;
    }

    public void Deal(Card a) //Deal
    {
        Card newCard = Instantiate(a);
        //Play some animation
        newCard.transform.SetParent(hand.transform);
        handDrop.currentSize++;
    }

}
