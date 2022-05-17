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
    private (float x, float y) _moveSpeed;

    private void OnEnable()
    {
        if (_playerInputs == null)
        {
            _playerInputs = new PlayerInputs();

            _playerInputs.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerInputs.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
            _playerInputs.PlayerInteraction.Interact.started += i => _interact = true;
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
        HandleCameraInput();
        HandleInteractInput();
    }

    public (float, float) HandleMovementInput()
    {
        _movementController.HandleMovement(_movementInput.x, _movementInput.y);

        _moveSpeed.x = _movementInput.x;
        _moveSpeed.y = _movementInput.y;
        return _moveSpeed;
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
