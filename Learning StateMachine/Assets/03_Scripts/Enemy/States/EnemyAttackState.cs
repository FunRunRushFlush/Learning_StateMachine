using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : State
{
    protected AttackDetails attackDetails;
    public EnemyAttackState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, Transform attackPosition) : base(entity, stateMachine, enemyData, animBoolName)
    {
        this.attackPosition = attackPosition;
    }

    public override void Enter()
    {
        base.Enter();

        entity.atsm.attackState = this;

        isAnimationFinished = false;
        entity.SetVelocity(0f);
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

    public virtual void TriggerAttack()
    {  }

    public virtual void FinishAttack()
    { isAnimationFinished = true; }
}
