using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    public bool wallSliding;

    [Header("Components: ")]
    public PlayerStats playerStats;
    public GroundCheck groundCheck;
    public WallCheck wallCheck;
    public Rigidbody2D rb;

    void Update()
    {
        if ((wallCheck.isTouchingWallRight || wallCheck.isTouchingWallLeft) && !groundCheck.isGrounded)
        {
            wallSliding = true;
        } else
        {
            wallSliding = false;
        }

        if (wallSliding)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -playerStats.wallSlidingSpeed, float.MaxValue));
        }
    }
}
