using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPickup : ItemPickup
{
    public override void Pickup()
    {
        PlayerProperties.honey += 1;
    }
}
