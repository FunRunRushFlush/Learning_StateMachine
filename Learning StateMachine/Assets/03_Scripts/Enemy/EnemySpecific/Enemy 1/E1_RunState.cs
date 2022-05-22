using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_RunState : EnemyRunState
{
    private E1_Enemy enemy;
    public E1_RunState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, E1_Enemy enemy) : base(entity, stateMachine, enemyData, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CheckLedge();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        entity.SetVelocity(enemyData.runVelocity);
        if (performCloseRangeAction)
        {
            attackModifier = 0;
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {

            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        else if (isRunTimeOver)
        {
            if (isPlayerInMinAggroRange)
            {
                stateMachine.ChangeState(enemy.detectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }


        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}