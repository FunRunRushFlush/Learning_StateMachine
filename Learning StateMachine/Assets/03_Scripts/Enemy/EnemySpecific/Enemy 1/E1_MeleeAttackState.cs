using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class E1_MeleeAttackState : EnemyMeleeAttackState
{
    private E1_Enemy enemy;
    public E1_MeleeAttackState(Entity entity, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName, Transform attackPosition, E1_Enemy enemy) : base(entity, stateMachine, enemyData, animBoolName, attackPosition)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        attackModifier = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (isPlayerInMaxAggroRange)
            {
                stateMachine.ChangeState(enemy.detectedState);
            }
            else
            {
                stateMachine.ChangeState(enemy.lookForPlayerState);
            }
        }
        else if(!isAnimationFinished)
        {
            entity.SetVelocity(enemyData.runVelocity);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        CheckMeleeAttack();
    }
    public override void FinishAttack()
    {
        base.FinishAttack();
    }


    public void CheckMeleeAttack()
    {
        Debug.Log("Im in CheckMeleeAttack");
        WeaponAttackDetails details = enemy.aggressiveWeaponData.AttackDetails[attackModifier];

        foreach (IDamageable item in detectedDamageablesEnemy.ToList())
        {
            Debug.Log("foreach loop in CheckMeleeAttack works" );
            item.Damage(details.damageAmount);

        }

        foreach (IKnockbackable item in detectedKnockbackablesEnemy.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, enemy.facingDirection);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        //Debug.Log("[AggresiveWeapon]AddToDetected Works");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Debug.Log("[AggresiveWeapon] IF(damageable !=null) | AddToDetected Works");

            detectedDamageablesEnemy.Add(damageable);
            Debug.Log("Added to the list");
        }
        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackablesEnemy.Add(knockbackable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        //Debug.Log("[AggresiveWeapon] RemoveToDetected Works");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageablesEnemy.Remove(damageable);
            Debug.Log("Removed from the list");
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackablesEnemy.Remove(knockbackable);
        }
    }
}
