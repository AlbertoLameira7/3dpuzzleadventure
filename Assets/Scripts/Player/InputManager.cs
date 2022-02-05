using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerInputs _playerInputs;
    [SerializeField] MovementController _movementController;
    [SerializeField] CameraController _cameraController;

    private Vector2 _movementInput;
    private Vector2 _cameraInput;

    private void OnEnable()
    {
        if (_playerInputs == null)
        {
            _playerInputs = new PlayerInputs();

            _playerInputs.PlayerMovement.Movement.performed += i => _movementInput = i.ReadValue<Vector2>();
            _playerInputs.PlayerMovement.Camera.performed += i => _cameraInput = i.ReadValue<Vector2>();
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
    }

    private void HandleMovementInput()
    {
        _movementController.HandleMovement(_movementInput.x, _movementInput.y);
    }

    private void HandleCameraInput()
    {
        _cameraController.HandleMovement(_cameraInput.x, _cameraInput.y);
    }
}
