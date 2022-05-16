using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/BaseData")]
public class EnemyData : ScriptableObject
{
    [Header("Idle State")]
    public float minIdleTime;
    public float maxIdleTime;

    [Header("Detecting player State")]
    public float minAggroDistance = 5f;
    public float maxAggroDistance = 15f;
    public LayerMask playerLayer;

    [Header("LookingForPlayer State")]
    public int amountOfTurns = 2;
    public float timeBetweenTurns = 0.5f;

    [Header("Grounded_MovementState")]
    public float walkVelocity = 10f;
    public float runVelocity = 15f;
    public float backwardsVelocity = 5f;
    public float runTime = 3f;
    public float longRangeActionTime = 1f;

    [Header("Attack State")]
    public float closeRangeActionDistance = 1f;
    public float attackRadius = 0.5f;
    public float attackDamage = 10f;
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
