using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectedState : State
{
    public EnemyDetectedState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(entity, stateMachine, enemyData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        performLongRangeAction = false;

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

        if((Time.time >= startTime + enemyData.longRangeActionTime)&& isPlayerInMaxAggroRange && !isPlayerInMinAggroRange)
        {
            performLongRangeAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
