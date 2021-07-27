using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuClose : MonoBehaviour
{
    private PlayerInteractions playerInteractions;

    void Start()
    {
        playerInteractions = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractions>();
        playerInteractions.SetInInteraction(true);
    }

    public void CloseInteraction()
    {
        playerInteractions.SetInInteraction(false);
        Destroy(gameObject);
    }
}
