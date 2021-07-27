using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    [Header("Components: ")]
    public WallSlide wallSlide;
    public WallCheck wallCheck;
    public PlayerStats playerStats;
    public Rigidbody2D rb;

    public bool wallJumping;

    private bool isTouchingRight;
    private float xInput;

    private void Update()
    {
        if (wallJumping)
        {
            rb.velocity = new Vector2(playerStats.xWallForce * (isTouchingRight ? -1 : 1), playerStats.yWallForce);
        }
    }

    public void SetIsTouchingRight(bool boolean)
    {
        isTouchingRight = boolean;
    }

    public void DoWallJump()
    {
        if (wallSlide.wallSliding)
        {
            wallJumping = true;
            Invoke("SetWallJumpingToFalse", playerStats.wallJumpTime);
        }
    }

    private void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }
}
