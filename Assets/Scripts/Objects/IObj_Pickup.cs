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
        if (InventoryManager.Instance.AddItem(_itemID, _itemName, _itemDescription)) {
            GameObject.Destroy(gameObject);
        }
    }
}
