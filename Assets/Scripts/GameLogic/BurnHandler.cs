using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: ddetermine if this needs to be separate from playhandler
//Probably, because it should do different things in the end? But should consider.

public class BurnHandler : MonoBehaviour
{
    DropZone burnZone;
    Card newCard = null;
    public bool hasCard = false;

    // Start is called before the first frame update
    void Awake()
    {
        burnZone = this.GetComponent<DropZone>();
    }

    private void Update() 
    {
        hasCard = (this.transform.childCount > 0);
        if (hasCard)
        {
            CheckForNewCards();
        }
    }

    //check for if a card has been dropped into the queue
    void CheckForNewCards()
    {
        for (int i = this.transform.childCount-1; i>=0; i--)
        {
            Card tempCard = this.transform.GetChild(i).GetComponent<Card>();
            if (tempCard != null)
            {
                newCard = tempCard;
            }
        }
    }

    /// <summary>
    /// Set dropzone on or off. 
    /// </summary>
    /// <param name="active">True for on</param>
    public void setMode(bool active)
    {
        burnZone.droppable=active;
    }

    public Card GetCard()
    {
        return newCard;
    }
}