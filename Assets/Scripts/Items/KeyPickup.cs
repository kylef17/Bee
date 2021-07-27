using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : ItemPickup
{
    public override void Pickup()
    {
        PlayerProperties.keys += 1;
    }
}
