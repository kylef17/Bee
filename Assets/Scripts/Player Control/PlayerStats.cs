using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/Player/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Move Stats: ")]
    public float moveSpeed = 10f;

    [Header("Jump Stats: ")]
    public float jumpForce;
    public int extraJumps = 0;
    public float holdJumpTime;
    public float doubleJumpForceMultiplier;

    [Header("Wall Jump Stats: ")]
    public float wallSlidingSpeed;
    public float xWallForce;
    public float yWallForce;
    public float wallJumpTime;

    [Header("Physics: ")]
    public float gravityScale = 20f;
    public float groundRaycastLength = 0.6f;
    public float groundRaycastOffset;
    public float wallRaycastLength = 0.6f;

    [Header("Input Stats: ")]
    public float jumpButtonGracePeriod = 0.25f;
    public float useDoubleJumpOrBuffferRaycastLength = 0.8f;
}
