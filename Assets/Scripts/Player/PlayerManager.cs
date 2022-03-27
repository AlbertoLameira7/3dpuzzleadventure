using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private InputManager _inputManager;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        _inputManager.HandleInput();
        //Debug.Log("This is nr of items in inventory: " + InventoryManager.GetNrItems());
    }

    private void FixedUpdate()
    {
        _inputManager.HandleFixedUpdateInput();
    }
}
