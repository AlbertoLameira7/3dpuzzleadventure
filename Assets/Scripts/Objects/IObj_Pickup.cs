using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObj_Pickup : BaseInteractableObject
{
    public override void Interact()
    {
        // call event to add item to inventory
        /*
            check if the item was added to the inventory, only remove it after. 
            something like:
            
            if (AddItem(id, name, description)) {
                GameObject.Destroy(gameObject);
            }
        */
        if(InventoryManager.AddItem(0, "cenas", "cenas")) {
            GameObject.Destroy(gameObject);
        }
    }
}
