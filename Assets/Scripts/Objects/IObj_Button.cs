using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObj_Button : BaseInteractableObject
{
    public override void Interact()
    {
        //Do Something
        GameObject.Destroy(gameObject);
    }
}
