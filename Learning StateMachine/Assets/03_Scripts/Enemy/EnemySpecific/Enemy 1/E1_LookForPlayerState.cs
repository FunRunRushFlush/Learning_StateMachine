using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_LookForPlayerState : EnemyLookForPlayerState
{
    private E1_Enemy enemy;

    public E1_LookForPlayerState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, E1_Enemy enemy) : base(entity, stateMachine, enemyData, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isPlayerInMaxAggroRange)
        {
            stateMachine.ChangeState(enemy.detectedState);
        }
        else if ( isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(enemy.moveState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
