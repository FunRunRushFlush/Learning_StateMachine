using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_MoveState : EnemyMoveState
{
    private E1_Enemy enemy; 
    public E1_MoveState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, E1_Enemy enemy) : base(entity, stateMachine, enemyData, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        isDetectingWall =enemy.CheckWall();
        isDetectingLedge = enemy.CheckLedge();

        if(isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(enemy.detectedState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            enemy.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
