using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTransitionState : State
{
    public EnemyAttackTransitionState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName) : base(entity, stateMachine, enemyData, animBoolName)
    {
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
