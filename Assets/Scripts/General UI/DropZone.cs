using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//Handles zones that can have objects dropped into them
//Accepts types of cards, equipments, depending on classification of 

//To Do:
//Determine how to handle current/max size in hand vs queue, etc. 
//clean up Droppable logic?

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image self;
    public Color NormalColor; //Likely unnecessary w/ proper images. Temp workaround. 
    public bool droppable;  //is the zone currently active
    public int currentSize; //num of elements in the zone.


    public enum ZoneType {Queue, Hand, Equipment}; //type of zone. Necessary?
    public ZoneType type; //See above


    void Start()
    {
        self = GetComponent<Image>();
        NormalColor= self.color;
        currentSize = 0;
        droppable = true;
    }
    private void Update() 
    {
        currentSize = this.transform.childCount;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }


    //DropTarget is real ugly, needs to be redone. 
    //Let GameManager handle rather than individual sections? 
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropTarget = eventData.pointerDrag;
        Card dropCard = dropTarget.GetComponent<Card>();
        // if (dropTarget!=null)
        // {
        //     if (type == ZoneType.Queue)
        //     {
        //         droppable = this.GetComponent<QueueHandler>().CheckIfDroppable(dropCard);
        //     }
        //     if (type == ZoneType.Hand)
        //     {
        //         droppable = this.GetComponent<HandHandler>().CheckIfDroppable(dropCard);
        //     }
        // }
        // else
        // {
        //     Equipment dropEquip = eventData.pointerDrag.GetComponent<Equipment>();
        //     if (type == ZoneType.Equipment)
        //     {
        //         droppable = this.GetComponent<EquipmentHandler>().CheckIfDroppable(dropEquip);
        //     }
        // }
        //  INSTEAD CALL SOME GAMEMANAGER LOGIC HERE
        if (droppable)
        {
            Draggable cardDraggable = dropTarget.transform.GetComponent<Draggable>();
            cardDraggable.initialParent = this.transform;
        }
    }
}
