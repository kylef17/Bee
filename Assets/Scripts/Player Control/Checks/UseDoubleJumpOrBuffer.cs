using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseDoubleJumpOrBuffer : MonoBehaviour
{
    public PlayerStats playerStats;
    public LayerMask groundLayer;
    public enum use { doubleJump, buffer}
    public use caseToUse;

    private Vector3 raycastOffset;

    void Update()
    {
        raycastOffset = new Vector3(playerStats.groundRaycastOffset, 0f, 0f);

        if (Physics2D.Raycast(transform.position + raycastOffset, Vector2.down, playerStats.useDoubleJumpOrBuffferRaycastLength, groundLayer) || Physics2D.Raycast(transform.position - raycastOffset, Vector2.down, playerStats.useDoubleJumpOrBuffferRaycastLength, groundLayer))
        {
            caseToUse = use.buffer;
        } else
        {
            caseToUse = use.doubleJump;
        }
    }
}
