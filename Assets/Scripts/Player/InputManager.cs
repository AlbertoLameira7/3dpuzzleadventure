using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInputs _playerInputs;
    [SerializeField] MovementController _movementController;
    [SerializeField] CameraController _cameraController;
    [SerializeField] PlayerInteractController _playerInteractController;

    private Vector2 _movementInput;
    private Vector2 _cameraInput;
    private bool _interact;

    private void OnEnable()
    {
        if (_playerInputs == null)
        {
            _playerInputs = new PlayerInputs();

            _playerInputs.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerInputs.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
            _playerInputs.PlayerInteraction.Interact.started += i => _interact = true;
            //_playerInputs.PlayerInteraction.Interact.canceled += i => _interact = false;
        }

        _playerInputs.Enable();
    }

    private void OnDisable()
    {
        _playerInputs.Disable();
    }

    public void HandleInput()
    {
        // handle all inputs
        HandleMovementInput();
        HandleCameraInput();
        HandleInteractInput();
    }

    private void HandleMovementInput()
    {
        _movementController.HandleMovement(_movementInput.x, _movementInput.y);
    }

    private void HandleCameraInput()
    {
        _cameraController.HandleMovement(_cameraInput.x, _cameraInput.y);
    }

    private void HandleInteractInput()
    {
        if (_interact)
        {
            _playerInteractController.HandleInteract();
            _interact = false;
        }
    }
}
