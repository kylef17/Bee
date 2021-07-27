using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Rigidbody2D rb;
    public PauseControl pauseControl;
    public PlayerMovement playerMovement;
    public PlayerJump playerJump;
    public PlayerStats playerStats;
    public PlayerInteractions playerInteractions;
    public WallSlide wallSlide;
    public WallJump wallJump;
    public WallCheck wallCheck;
    public GroundCheck groundCheck;
    public UseDoubleJumpOrBuffer useDoubleJumpOrBuffer;

    public bool allowInput = true;

    // Input variables
    private Vector2 inputDirection;

    //Jump buffer float
    private float? lastGroundedTime;
    private float? jumpButtonPressedTime;

    void Update()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        InteractionUpdateChecks();
        JumpUpdateChecks();
    }

    void FixedUpdate()
    {
        // Call the buffered jump
        if (useDoubleJumpOrBuffer.caseToUse == UseDoubleJumpOrBuffer.use.buffer)
        {
            if (Time.time - lastGroundedTime <= playerStats.jumpButtonGracePeriod)
            {
                if (Time.time - jumpButtonPressedTime <= playerStats.jumpButtonGracePeriod)
                    AllJumpFunctions();
            }
        }

        // Fixed update character movement calls 
        if (!wallJump.wallJumping)
        {
            playerMovement.Move(inputDirection.x);
        }
    }

    void OnDisable()
    {
        rb.velocity = Vector2.zero;
        playerInteractions.DoInteraction(false);
    }

    private void InteractionUpdateChecks()
    {
        if (inputDirection.y == 1)
        {
            playerInteractions.DoInteraction(true);
        } else
        {
            playerInteractions.DoInteraction(false);
        }
    }

    private void JumpUpdateChecks()
    {
        //Update the last grounded time
        if (groundCheck.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        //Check if pressed jump key
        if (Input.GetButtonDown("Jump"))
        {
            wallJump.SetIsTouchingRight(wallCheck.isTouchingWallRight);
            wallJump.DoWallJump();

            if (useDoubleJumpOrBuffer.caseToUse == UseDoubleJumpOrBuffer.use.buffer)
            {
                jumpButtonPressedTime = Time.time;
            }
            else if (useDoubleJumpOrBuffer.caseToUse == UseDoubleJumpOrBuffer.use.doubleJump)
            {
                playerJump.Jump();
            }
        }

        //Check if holding jump key
        if (Input.GetButton("Jump"))
        {
            playerJump.HoldJump();
        }

        //Check if stopped holding jump key
        if (Input.GetButtonUp("Jump"))
        {
            playerJump.StopHoldJump();
        }
    }

    private void AllJumpFunctions()
    {
        playerJump.Jump();

        jumpButtonPressedTime = null;
        lastGroundedTime = null;
    }
}
