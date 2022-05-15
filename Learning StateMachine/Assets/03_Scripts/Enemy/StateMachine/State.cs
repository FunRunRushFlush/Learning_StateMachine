using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected EnemyStateMachine stateMachine;
    protected Entity entity;
    protected EnemyData enemyData;


    protected float startTime;
    protected string animBoolName;

    protected bool isDetectingWall;
    protected bool isDetectingLedge;

    protected bool isPlayerInMinAggroRange;
    protected bool isPlayerInMaxAggroRange;

    protected bool isRunTimeOver;
    protected bool performLongRangeAction;


    public State(Entity entity, EnemyStateMachine stateMachine,EnemyData enemyData, string animBoolName)
    {
        this.entity = entity;
        this.stateMachine = stateMachine;
        this.animBoolName = animBoolName;
        this.enemyData = enemyData;
    }
    public virtual void Enter()
    {
        startTime = Time.time;
        entity.animator.SetBool(animBoolName, true);
        Debug.Log(animBoolName);
    }
    public virtual void Exit()
    {
        entity.animator.SetBool(animBoolName, false);
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {

        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CheckLedge();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
    }

}
