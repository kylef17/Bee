using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public PlayerStateController playerStateController;
    public string interactionTag = "Interactable";
    public bool doInteraction;
    public bool inInteraction;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(interactionTag) && doInteraction && !inInteraction)
        { 
            other.gameObject.GetComponent<Interactions>().Interact();
            SetInInteraction(true);
        }
    }

    public void DoInteraction(bool boolean)
    {
        doInteraction = boolean;
    }

    public void SetInInteraction(bool boolean)
    {
        inInteraction = boolean;
        if (boolean == true)
        {
            playerStateController.SetState(PlayerStateController.States.noMovement);
        } else
        {
            playerStateController.SetState(PlayerStateController.States.freeMovement);
        }

    }
}
