using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1_AttackTrasitionState : EnemyAttackTransitionState
{
    private E1_Enemy enemy;

    public E1_AttackTrasitionState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, E1_Enemy enemy) : base(entity, stateMachine, enemyData, animBoolName)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
