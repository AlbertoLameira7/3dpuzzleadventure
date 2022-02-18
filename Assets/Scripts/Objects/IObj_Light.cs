using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObj_Light : BaseInteractableObject
{
    [SerializeField] List<GameObject> _lights;

    private bool _lightsOn = true;

    private void Awake()
    {
        _lightsOn = true;
    }

    public override void Interact()
    {
        // Toggle Lights
        ToggleLights();
    }

    private void ToggleLights()
    {
        _lightsOn = _lightsOn ? false : true;
        HandleLights();
    }

    private void HandleLights()
    {
        foreach (var _light in _lights)
        {
            _light.SetActive(_lightsOn);
        }
    }
}
