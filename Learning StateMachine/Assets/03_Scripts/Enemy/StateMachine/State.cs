using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
    protected bool isAllTurnsDone;
    protected bool isAllTurnsTimeDone;
    protected bool flipImmediatly;
    protected float lastTurnTime;
    protected int amountOfTurnsDone;
    protected int attackModifier;

    protected bool isRunTimeOver;
    protected bool performLongRangeAction;
    protected bool performCloseRangeAction;
    protected bool isAnimationFinished;

    protected Transform attackPosition;

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
        Debug.Log("isPlayerInMaxAggroRange " + isPlayerInMaxAggroRange);
        isDetectingWall = entity.CheckWall();
        isDetectingLedge = entity.CheckLedge();
        isPlayerInMinAggroRange = entity.CheckPlayerInMinAggroRange();
        isPlayerInMaxAggroRange = entity.CheckPlayerInMaxAggroRange();
        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

}
