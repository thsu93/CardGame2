using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnHandler : MonoBehaviour
{
    DropZone burnZone;
    GameManager manager;
    public Character associatedCharacter;
    // Start is called before the first frame update
    void Awake()
    {
        burnZone = this.GetComponent<DropZone>();
        GameObject ManagerHolder = GameObject.Find("GameManager");
        manager = ManagerHolder.GetComponent<GameManager>();
    }

    // // Update is called once per frame
    // void Update()
    // {
    //     //finds draggables, executes Burn, then deletes them. 
    //     Card d = this.GetComponentInChildren<Card>();
    //     if (d != null)
    //     {
    //         Burn(d);
    //     }
    // }

    // void Burn(Card card)
    // {
    //     associatedCharacter.charDeck.AddToBurn(card);
    //     manager.ExecuteTurn(card.burnEffect);
    //     //call gamemanager with card to burn, then destroy card;
    //     Destroy(card.gameObject);
    // }

    public void setMode(bool active)
    {
        burnZone.droppable=active;
    }
}