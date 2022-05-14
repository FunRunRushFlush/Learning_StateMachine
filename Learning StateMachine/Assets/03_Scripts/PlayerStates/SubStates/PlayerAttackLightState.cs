using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttackLightState : PlayerAbilityState
{
    protected SO_AggressiveWeaponData aggressiveWeaponData;




    private List<IDamageable> detectedDamageables = new List<IDamageable>();
    private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();

    private bool lightAttack;
    public PlayerAttackLightState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        lightAttack = true;
        attackModifier = 0;
        yInput = player.InputHandler.NormInputY;

        player.Animator.SetInteger("attackModifier", attackModifier);
        player.Animator.SetBool("lightAttack", lightAttack);

       
        if (yInput == -1 && isGrounded)
        {
            attackModifier = 2;
            player.Animator.SetInteger("attackModifier", attackModifier);
        }
        else if (!isGrounded)
        {
            attackModifier = 1;
            player.Animator.SetInteger("attackModifier", attackModifier);
        }

        player.SetVelocityX(playerData.attackVelocity);


    }

    public override void Exit()
    {
        base.Exit();

        lightAttack = false;
        attackModifier = 0;
        player.Animator.SetInteger("attackModifier", attackModifier);
        player.Animator.SetBool("lightAttack", lightAttack);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

      

        player.SetVelocityX(playerData.attackVelocity);

        if (isAnimationFinished && isGrounded)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        if (isAnimationFinished && !isGrounded)
        {
            stateMachine.ChangeState(player.InAirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationActionTrigger()
    {
        base.AnimationActionTrigger();

        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        WeaponAttackDetails details = aggressiveWeaponData.AttackDetails[attackModifier];

        foreach (IDamageable item in detectedDamageables.ToList())
        {
            item.Damage(details.damageAmount);

        }

        foreach (IKnockbackable item in detectedKnockbackables.ToList())
        {
            item.Knockback(details.knockbackAngle, details.knockbackStrength, player.FacingDirection);
        }
    }

    public void AddToDetected(Collider2D collision)
    {
        //Debug.Log("[AggresiveWeapon]AddToDetected Works");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            //Debug.Log("[AggresiveWeapon] IF(damageable !=null) | AddToDetected Works");

            detectedDamageables.Add(damageable);
        }
        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackables.Add(knockbackable);
        }
    }

    public void RemoveFromDetected(Collider2D collision)
    {
        //Debug.Log("[AggresiveWeapon] RemoveToDetected Works");

        IDamageable damageable = collision.GetComponent<IDamageable>();

        if (damageable != null)
        {
            detectedDamageables.Remove(damageable);
        }

        IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

        if (knockbackable != null)
        {
            detectedKnockbackables.Remove(knockbackable);
        }
    }
    #region Animation Triggers

    //public virtual void AnimationFinishTrigger()
    //{
    //    state.AnimationFinishTrigger();
    //}

    //public virtual void AnimationStartMovementTrigger()
    //{
    //    state.SetPlayerVelocity(weaponData.movementSpeed[attackCounter]);
    //}

    //public virtual void AnimationStopMovementTrigger()
    //{
    //    state.SetPlayerVelocity(0f);
    //}

    //public virtual void AnimationTurnOffFlipTrigger()
    //{
    //    state.SetFlipCheck(false);
    //}

    //public virtual void AnimationTurnOnFlipTigger()
    //{
    //    state.SetFlipCheck(true);
    //}

    

    #endregion
}
