using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/BaseData")]
public class EnemyData : ScriptableObject
{
    [Header("Grounded State")]
    public float minIdleTime;
    public float maxIdleTime;

    public float minAggroDistance = 5f;
    public float maxAggroDistance = 15f;
    public LayerMask playerLayer;

    [Header("Grounded_SubMovementState")]
    public float walkVelocity = 10f;
    public float runVelocity = 15f;
    public float backwardsVelocity = 5f;
    public float runTime = 3f;
    public float longRangeActionTime = 1f;

    [Header("Crouching State")]
    public float crouchVelocity = 3f;
    public float crouchColliderHeight = 1.6f;
    public float standColliderHeight = 2.6f;
    [Header("Backdash State")]
    public float dashVelocityX = 15f;
    public float dashVelocityY = 5f;




    [Header("Jump State")]
    public float jumpVelocity = 15f;

    [Header("Attack State")]
    public float attackVelocity = 0f;


    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance;
    public float ledgeCheckDistance;
    public LayerMask groundLayer;


}
