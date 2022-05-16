using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_DetectedState : EnemyDetectedState
{
    private E1_Enemy enemy;
    public E1_DetectedState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, E1_Enemy enemy) : base(entity, stateMachine, enemyData, animBoolName)
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

        if(performCloseRangeAction)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (performLongRangeAction)
        {
            
            stateMachine.ChangeState(enemy.runState);
        }
        else if(!isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(enemy.lookForPlayerState);
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
