using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookForPlayerState : State
{
    public EnemyLookForPlayerState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(entity, stateMachine, enemyData, animBoolName)
    {}

    public override void Enter()
    {
        base.Enter();

        isAllTurnsDone = false;
        isAllTurnsTimeDone = false;

        lastTurnTime = startTime;
        amountOfTurnsDone = 0;

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(flipImmediatly)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
            flipImmediatly = false;
        }
        else if (Time.time >= lastTurnTime + enemyData.timeBetweenTurns && !isAllTurnsDone)
        {
            entity.Flip();
            lastTurnTime = Time.time;
            amountOfTurnsDone++;
        }

        if(amountOfTurnsDone >= enemyData.amountOfTurns)
        {
            isAllTurnsDone = true;
        }

        if(Time.time >= lastTurnTime + enemyData.timeBetweenTurns && isAllTurnsDone)
        {
            isAllTurnsTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetFlipImmediatly(bool flip)
    {
        flipImmediatly = flip;
    }
}
