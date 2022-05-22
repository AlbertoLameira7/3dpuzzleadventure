using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObj_Pickup : BaseInteractableObject
{
    [SerializeField] private int _itemID = 9999;
    [SerializeField] private string _itemName = "Null";
    [SerializeField] private string _itemDescription = "Null";

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
        if(InventoryManager.AddItem(_itemID, _itemName, _itemDescription)) {
            GameObject.Destroy(gameObject);
        }
    }
}
