using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/BaseData")]
public class PlayerData : ScriptableObject
{
    [Header("Grounded State")]
    
    [Header("Grounded_SubMovementState")]
    public float walkVelocity = 10f;
    public float runVelocity = 15f;
    public float backwardsVelocity = 5f;
    [Header("Crouching State")]
    public float crouchVelocity = 3f;
    public float crouchColliderHeight = 1.6f;
    public float standColliderHeight = 2.6f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    
    [Header("Attack State")]
    public float attackVelocity = 0f;


    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;


}
