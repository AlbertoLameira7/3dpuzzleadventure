using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractableObject : MonoBehaviour, IInteractable
{
    public bool CanInteract()
    {
        return false;
    }

    public bool ReadyToInteract()
    {
        return false;
    }

    public virtual void Interact() 
    {
        // Should not do anything, strictly for use of sub-classes, log for future debug reasons
        Debug.LogWarning("Warning, Object is calling BaseInteractableObject Interact().", transform);
    }
}
