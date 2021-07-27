using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Interactable/Pick Up On Interact")]
public class PickUpOnInteract : Interactable
{
    public ItemPickup item;

    public override void Interact()
    {
        item.Pickup();
    }
}
