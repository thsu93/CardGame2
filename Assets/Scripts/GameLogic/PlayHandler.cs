using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Convert dropped Cards to QueueCards.  
//QueueCards cannot be rearranged, can be clicked to return to hand as a card.
//When queue is filled, will lock out new cards.

//To Do:
//Revisit how to handle dropzone vs AP logic 
//clean up the button creation code, decide where to place button

public class PlayHandler : MonoBehaviour
{
    DropZone queueDrop;
    Card newCard = null;
    public bool hasCard = false;

    private void Awake() 
    {
        queueDrop = this.GetComponent<DropZone>();
    }

    void Reset()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void Update() 
    {
        if (this.transform.childCount > 0)
        {
            CheckForNewCards();
            hasCard = true;
        }
    }

    public void setMode(bool active)
    {
        queueDrop.droppable = active;
    }


    //check for if a card has been dropped into the queue
    void CheckForNewCards()
    {
        for (int i = this.transform.childCount-1; i>=0; i--)
        {
            Card tempCard = this.transform.GetChild(i).GetComponent<Card>();
            if (tempCard != null)
            {
                // Old, when was using queue icons.
                // QueueCard NewQueue = Instantiate(tempCard.matchingQueueCard);
                // NewQueue.transform.SetParent(this.transform);
                // NewQueue.transform.SetAsFirstSibling();
                // Destroy(tempCard.gameObject);
                newCard = tempCard;
            }
        }
    }

    public Card GetCard()
    {
        hasCard = false;
        return newCard;
    }
}
