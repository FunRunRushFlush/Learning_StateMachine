using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : State
{
    public EnemyIdleState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(entity, stateMachine, enemyData, animBoolName)
    {
    }

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;

    protected float idleTime;

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if(flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log("isIdleTimeOver ? "+ isIdleTimeOver);

        if(Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip;
    }

    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(enemyData.minIdleTime, enemyData.maxIdleTime); 
    }
}
