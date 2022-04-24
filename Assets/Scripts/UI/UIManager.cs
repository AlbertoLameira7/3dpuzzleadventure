using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _interactionPopUp;

    void OnEnable()
    {
        PlayerInteractController.ShowInteractionPopUp += ShowInteractionPopUp;
        PlayerInteractController.HideInteractionPopUp += HideInteractionPopUp;
    }

    void OnDisable()
    {
        PlayerInteractController.ShowInteractionPopUp -= ShowInteractionPopUp;
        PlayerInteractController.HideInteractionPopUp -= HideInteractionPopUp;
    }

    void ShowInteractionPopUp()
    {
        if (_interactionPopUp.activeSelf)
            return;

        _interactionPopUp.SetActive(true);
    }

    void HideInteractionPopUp()
    {
        if (!_interactionPopUp.activeSelf)
            return;

        _interactionPopUp.SetActive(false);
    }
}
