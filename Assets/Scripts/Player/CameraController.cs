using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _maxCameraPivotAngle = 60;
    [SerializeField] float _minCameraPivotAngle = -60;
    [SerializeField][Range(0.01f, 1)] float _mouseXSensitivity = 0.2f;
    [SerializeField][Range(0.01f, 1)] float _mouseYSensitivity = 0.1f;
    [SerializeField] bool _invertMouseX = true;
    [SerializeField] bool _invertMouseY = true;

    private float _tmpHorizontalValue, _tmpVerticalValue;
    private Vector3 _cameraRotation;
    private Quaternion _targetRotation;
    private int _invertMouseXValue, _invertMouseYValue;


    private void Awake()
    {
        SetMouseValues();
    }

    private void SetMouseValues()
    {
        _invertMouseXValue = _invertMouseX ? -1 : 1;
        _invertMouseYValue = _invertMouseY ? -1 : 1;
    }

    public void HandleMovement(float horizontal, float vertical)
    {
        RotateCamera(horizontal, vertical);
    }

    private void RotateCamera(float horizontal, float vertical)
    {
        _tmpVerticalValue = _tmpVerticalValue + (vertical) * _invertMouseYValue * _mouseYSensitivity;
        _tmpHorizontalValue = _tmpHorizontalValue - (horizontal) * _invertMouseXValue * _mouseXSensitivity;
        _tmpVerticalValue = Mathf.Clamp(_tmpVerticalValue, _minCameraPivotAngle, _maxCameraPivotAngle);

        _cameraRotation = Vector3.zero;
        _cameraRotation.y = _tmpHorizontalValue;
        _cameraRotation.x = _tmpVerticalValue;

        _targetRotation = Quaternion.Euler(_cameraRotation);

        transform.rotation = _targetRotation;
    }
}
