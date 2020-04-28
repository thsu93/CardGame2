using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO:
//Decide what to do with this code

public class EquipmentHandler : MonoBehaviour
{
    public enum EquipmentTypes {Head, Chest, Arm, Leg, Weapon, Inventory};
    public EquipmentTypes type;
    DropZone EquipZone;
    // Start is called before the first frame update
    void Start()
    {
        EquipZone = this.GetComponent<DropZone>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool CheckIfDroppable(Equipment dropTarget)
    {
        bool droppable = (dropTarget.type == type);
        return droppable; 
    }

    public void Reset() 
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }
}

