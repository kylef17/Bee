using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public PlayerStats playerStats;
    public WallCheck wallCheck;

    public LayerMask groundLayer;
    public bool isGrounded;
    public int extraJumpsLeft;

    private Vector3 raycastOffset;

    void Update()
    {
        isGrounded = Physics2D.Raycast(transform.position + raycastOffset, Vector2.down, playerStats.groundRaycastLength, groundLayer) || Physics2D.Raycast(transform.position - raycastOffset, Vector2.down, playerStats.groundRaycastLength, groundLayer);
        raycastOffset = new Vector3(playerStats.groundRaycastOffset, 0f, 0f);

        if (isGrounded || wallCheck.isTouchingWallLeft || wallCheck.isTouchingWallRight)
        {
            extraJumpsLeft = playerStats.extraJumps;
        }
    }

    void OnDrawGizmos()
    {
        raycastOffset = new Vector3(playerStats.groundRaycastOffset, 0f, 0f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + raycastOffset, transform.position + raycastOffset + Vector3.down * playerStats.groundRaycastLength);
        Gizmos.DrawLine(transform.position - raycastOffset, transform.position - raycastOffset + Vector3.down * playerStats.groundRaycastLength);
    }

}
