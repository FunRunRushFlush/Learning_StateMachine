using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunState : State
{
    public EnemyRunState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(entity, stateMachine, enemyData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();

        isRunTimeOver = false;
        entity.SetVelocity(enemyData.runVelocity);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + enemyData.runTime)
        {
            isRunTimeOver = true;
            Debug.Log("isRunTimeOver " + isRunTimeOver);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
