using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerStats playerStats;
    public GroundCheck groundCheck;

    [Header("Components: ")]
    public Rigidbody2D rb;

    void Update()
    {
        if (rb.gravityScale != playerStats.gravityScale)
        {
            rb.gravityScale = playerStats.gravityScale;
        }
    }

    public void Move(float horizontalInput)
    {
        rb.velocity = new Vector2(horizontalInput * playerStats.moveSpeed, rb.velocity.y);
    }
}
