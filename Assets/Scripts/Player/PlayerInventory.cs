using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private int _id;
    private string _name;
    private string _description;

    public Item(int id, string name, string description) {
        _id = id;
        _name = name;
        _description = description;
    }

    public int getID() {
        return _id;
    }

    public string getName() {
        return _name;
    }

    public string getDescription() {
        return _description;
    }
}

interface IInventory
{
    bool AddItem();
    bool RemoveItemByID();
    bool CheckIfItemExistsByID();
    int GetNrItems();
}

public class PlayerInventory : MonoBehaviour, IInventory
{
    [SerializeField] private List<Item> _items = new List<Item>();

    public bool AddItem(int id, string name, string description) {
        // add item to list
        _items.Add(new Item(id, name, description));
        return true;
    }

    public bool RemoveItemByID(int id) {
        // remove item with specific ID from list
        Item _tmp = _items.Find(itm => itm.getID() == id);

        if (_tmp != null) {
            Debug.Log("Item with id: " + id + " exists in list, removing from list.");
            _items.Remove(_tmp);
            return true;
        } else {
            Debug.Log("Item with id: " + id + " doesn't exist in the list.");
            return false;
        }
    }

    public bool CheckIfItemExistsByID(int id) {
        foreach (Item item in _items) {
            if (item.getID() == id) {
                return true;
            }
        };

        return false;
    }

    public int GetNrItems() {
        return _items.Count;
    }
}
