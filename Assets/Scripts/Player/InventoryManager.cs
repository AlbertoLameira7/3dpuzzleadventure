using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IInventory
{
    public static InventoryManager Instance { get; private set; }
    [SerializeField] private PlayerInventory _playerInventory;

    void Awake() {
        if (Instance != null && Instance != this)
            Destroy(this);
        else {
            Instance = this;
        }
    }

    public bool AddItem(int id, string name, string description) {
        return _playerInventory.AddItem(id, name, description);
    }

    public bool RemoveItemByID(int id) {
        return _playerInventory.RemoveItemByID(id);
    }

    public bool CheckIfItemExistsByID(int id) {
        return _playerInventory.CheckIfItemExistsByID(id);
    }

    public int GetNrItems() {
        return _playerInventory.GetNrItems();
    }
}
