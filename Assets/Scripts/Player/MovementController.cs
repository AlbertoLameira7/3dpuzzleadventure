using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _playerSpeed = 1000;

    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void HandleMovement(float horizontal, float vertical)
    {
        transform.rotation = Quaternion.Euler(0, _cameraTransform.eulerAngles.y, 0);
        //Vector3 _mov = transform.InverseTransformVector(new Vector3(vertical, IsGroundedToInt(),horizontal));
        Vector3 _mov = (transform.forward * vertical) + (transform.right * horizontal);
        _rb.velocity = _mov * _playerSpeed * Time.deltaTime;
    }

    public float GetPlayerSpeed()
    {
        return _playerSpeed;
    }
}
