using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Ability to remove cards from hand? 
//DESIGN Q: what kind of hand manipulation skills?

/// <summary>
/// Determines if the hand is full, and clears the hand if needed to reset
/// </summary>
public class HandHandler : MonoBehaviour
{
    int maxSize = 8;

    public DropZone HandZone;
    // Start is called before the first frame update
    void Start()
    {
    }

    public bool CheckIfDroppable()
    {
        bool droppable = !(HandZone.currentSize>=maxSize);
        return droppable;
    }

    public void Reset() 
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public int getMax()
    {
        return maxSize;
    }
}
