using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObj_Door : BaseInteractableObject
{
    [SerializeField] private bool _requiresItemToOpen = false;

    [SerializeField] private int _itemIDToOpenDoor = -1;

    private bool _doorOpen = false;
    private Animator _anim;

    private void Awake() {
        _anim = gameObject.GetComponent<Animator>();
    }

    public override void Interact() {
        if (_requiresItemToOpen) {
            // check if item is in inventory
            if (InventoryManager.CheckIfItemExistsByID(_itemIDToOpenDoor)) {
                // item exists in inventory, open door
                Debug.Log("Open door with item ID: " + _itemIDToOpenDoor);
                ToggleDoor();
            } else
                Debug.Log("Can't open door, missing item: " + _itemIDToOpenDoor);
        } else {
            ToggleDoor();
        }
    }

    private void ToggleDoor() {
        _doorOpen = _doorOpen ? false : true;
        HandleDoor();
    }

    private void HandleDoor() {
        if (_doorOpen)
            _anim.SetTrigger("Open_Door"); // open door
        else 
            _anim.SetTrigger("Close_Door"); // close door
    }
}
