using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public Interactable interactSO;

    public void Interact()
    {
        interactSO.Interact();
    }
}
