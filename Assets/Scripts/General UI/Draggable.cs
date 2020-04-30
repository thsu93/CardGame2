using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//THIS VS HOVERING?


public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    static float scaleMult = 1.5f;
    private Vector3 initScale; 
    private Vector3 magScale;

    public Transform initialParent = null;
    public DropZone initialZone = null;
    
    //for card movement, hold empty spaces for cards when moving in hand. 
    private float xOffset = 0;
    private float yOffset = 0;
    GameObject placeholder = null;

    public bool dragging;

    private void Start() {
        initScale = this.transform.localScale;
        magScale = this.transform.localScale * scaleMult;
        dragging = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //let game know dragging object
        dragging = true;

        //remember which panel card came from
        initialParent = this.transform.parent;
        initialZone = initialParent.GetComponent<DropZone>();
        initialZone.currentSize--;

        //correct for non-centered clicks
        xOffset = this.transform.position.x - eventData.position.x;
        yOffset = this.transform.position.y - eventData.position.y;

        //create an invisible card to hold current card's place
        createPlaceholder();

        this.transform.SetParent(this.transform.parent.parent);

        //Magnify card, for readability
        this.transform.localScale = magScale;

        //allow for click-through on card
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        //change drop zone colors.  Likely unnecessary. 
        DropZone[] zones = GameObject.FindObjectsOfType<DropZone>();
        for (int i=0; i<zones.Length; i++)
        {
            if (zones[i].droppable)
            {
                Color tempColor = zones[i].NormalColor;
                zones[i].self.color = new Color(tempColor.r, tempColor.g, tempColor.b, 0.2f);   
            }
        }

    }


    public void OnDrag(PointerEventData eventData)
    {
        //move the card
        this.transform.position = new Vector2(eventData.position.x + xOffset, eventData.position.y + yOffset);
        movePlaceholder();

        //See if over a drop zone
        //If so, what border effect to add
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //reset to normal size
        this.transform.localScale = initScale;

        //send card back to panel.  
        //Activates after OnDrop, so drop in other zone has higher priority
        this.transform.SetParent(initialParent);

        //re-allow card clicks
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        
        //correct colors
        DropZone[] zones = GameObject.FindObjectsOfType<DropZone>();
        for (int i=0; i<zones.Length; i++)
        {
            if (zones[i].droppable)
            {
                zones[i].self.color = zones[i].NormalColor;
            }
        }

        //move card to replace placeholder
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
        
        
        Destroy(placeholder);

        dragging = false;
    }

    
    private void createPlaceholder() //Creates a placeholder element to fill space of a dragged 
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent (this.transform.parent);
        LayoutElement le = placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth*scaleMult;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight*scaleMult;
        le.flexibleWidth = 0;
        le.flexibleHeight = 0;
        placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());
    }

    private void movePlaceholder()
    {
        //check order of where selected card is relative to other cards 
        int placeholderIndex = initialParent.childCount;
        for (int i = 0; i < initialParent.childCount; i++)
        {
            if (this.transform.position.x < initialParent.GetChild(i).position.x)
            {
                placeholderIndex = i;
                if(placeholder.transform.GetSiblingIndex() < i)
                {
                    placeholderIndex--;
                }
                break;
            }
        }
        placeholder.transform.SetSiblingIndex(placeholderIndex);
    }
}
