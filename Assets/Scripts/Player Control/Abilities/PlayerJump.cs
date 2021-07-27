using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Components: ")]
    public PlayerStats playerStats;
    public Rigidbody2D rb;
    public GroundCheck groundCheck;

    private float jumpTimeCounter;
    private bool isJumping;

    public void Jump()
    {
        if (groundCheck.isGrounded)
        {
            jumpTimeCounter = playerStats.holdJumpTime;
        }
        if (groundCheck.extraJumpsLeft > 0 && !groundCheck.isGrounded)
        {
            rb.velocity = Vector2.up * playerStats.jumpForce * playerStats.doubleJumpForceMultiplier;
            isJumping = true;
            groundCheck.extraJumpsLeft--;
            jumpTimeCounter = 0f;
        } else if (groundCheck.isGrounded)
        {
            rb.velocity = Vector2.up * playerStats.jumpForce;
            isJumping = true;
            jumpTimeCounter = playerStats.holdJumpTime;
        }
    }

    public void HoldJump()
    {
        if (isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * playerStats.jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }
    }

    public void StopHoldJump()
    {
        isJumping = false;
    }
}
