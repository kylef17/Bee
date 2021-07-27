using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnPickup : MonoBehaviour
{
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
