using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractController : MonoBehaviour
{
    [SerializeField] float _interactDistance = 2f;
    [SerializeField] Camera _playerCamera;

    private RaycastHit _hit;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = _playerCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Physics.Raycast(ray, out _hit, _interactDistance);
    }

    public void HandleInteract()
    {
        Debug.Log("Pressed interact!");
        if (_hit.collider != null && _hit.collider.gameObject.tag == "cenas")
        {
            _hit.collider.gameObject.GetComponent<IInteractable>().Interact();
        }
    }
}
