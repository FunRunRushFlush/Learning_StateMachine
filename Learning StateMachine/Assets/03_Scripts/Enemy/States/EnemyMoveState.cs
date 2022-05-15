using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : State
{
    public EnemyMoveState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(entity, stateMachine, enemyData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(enemyData.walkVelocity);

        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CheckLedge();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        entity.SetVelocity(enemyData.walkVelocity);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
