using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
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

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private static List<Item> _items = new List<Item>();

    public static bool AddItem(int id, string name, string description) {
        // add item to list
        _items.Add(new Item(id, name, description));
        return true;
    }

    public static bool RemoveItemByID(int id) {
        // remove item with specific ID from list
        Item _tmp = null;

        foreach (Item item in _items) {
            if (item.getID() == id) {
                _tmp = item;
                break;
            }
        };

        if (_tmp != null) {
            Debug.Log("Item with id: " + id + " exists in list, removing from list.");
            _items.Remove(_tmp);
            return true;
        } else {
            Debug.Log("Item with id: " + id + " doesn't exist in the list.");
            return false;
        }
    }

    public static bool CheckIfItemExistsByID(int id) {
        foreach (Item item in _items) {
            if (item.getID() == id) {
                return true;
            }
        };

        return false;
    }

    public static int GetNrItems() {
        return _items.Count;
    }
}
