using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;

    public void TriggerRespawn()
    {
        player.transform.position = transform.position;
    }
}
