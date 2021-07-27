using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public PlayerStats playerStats;

    public LayerMask wallLayer;
    public bool isTouchingWallRight;
    public bool isTouchingWallLeft;

    void Update()
    {
        isTouchingWallRight = Physics2D.Raycast(transform.position, Vector2.right, playerStats.wallRaycastLength, wallLayer);
        isTouchingWallLeft =  Physics2D.Raycast(transform.position, Vector2.left, playerStats.wallRaycastLength, wallLayer);
    }
}
