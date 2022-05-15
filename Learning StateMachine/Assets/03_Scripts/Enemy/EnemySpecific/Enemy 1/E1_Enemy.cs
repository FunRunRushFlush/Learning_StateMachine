using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_Enemy : Entity
{
    
    public E1_IdleState idleState { get; private set; }
    public E1_MoveState moveState { get; private set; }
    public E1_DetectedState detectedState { get; private set; }
    public E1_RunState runState { get; private set; }

    public override void Start()
    {
        base.Start();

        moveState = new E1_MoveState(this, stateMachine, enemyData, "move", this);
        idleState = new E1_IdleState(this, stateMachine, enemyData, "idle", this);
        detectedState = new E1_DetectedState(this, stateMachine, enemyData, "playerDetected", this);
        runState = new E1_RunState(this, stateMachine, enemyData, "run", this);


        stateMachine.Initialize(idleState);
    }

}
