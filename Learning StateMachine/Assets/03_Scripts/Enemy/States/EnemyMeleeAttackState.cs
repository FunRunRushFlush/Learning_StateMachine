using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyMeleeAttackState : EnemyAttackState
{
    protected List<IDamageable> detectedDamageablesEnemy = new List<IDamageable>();
    protected List<IKnockbackable> detectedKnockbackablesEnemy = new List<IKnockbackable>();
    
    public EnemyMeleeAttackState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, Transform attackPosition) : base(entity, stateMachine, enemyData, animBoolName, attackPosition)
    {
    }

    public override void Enter()
    {
        base.Enter();

        attackDetails.damageAmount = enemyData.attackDamage;
        attackPosition.position = entity.aliveGo.transform.position;
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

    public override void TriggerAttack()
    {
        base.TriggerAttack();
    }
    public override void FinishAttack()
    {
        base.FinishAttack();
    }
   



}
