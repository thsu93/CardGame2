using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To Do:
//Decide what to do with this

public class HandHandler : MonoBehaviour
{
    int maxSize = 8;
    DropZone HandZone;
    // Start is called before the first frame update
    void Start()
    {
        HandZone = this.GetComponent<DropZone>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool CheckIfDroppable(Card d)
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

    //Void to 
}
