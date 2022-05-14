using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerAttackLightState : PlayerAbilityState
{
  


    public bool lightAttack;
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
        player.sword.EnterSword();
        //yInput = player.InputHandler.NormInputY;
        //xInput = player.InputHandler.NormInputX;
      

        
        //player.Animator.SetBool("lightAttack", lightAttack);
        //player.Animator.SetInteger("attackModifier", attackModifier);
        //player.sword.animator.SetBool("lightAttack", lightAttack);


        //if (yInput == -1 && isGrounded)
        //{
        //    attackModifier = 2;
        //    player.Animator.SetInteger("attackModifier", attackModifier);
        //}
        //else if (!isGrounded)
        //{
        //    attackModifier = 1;
        //    player.Animator.SetInteger("attackModifier", attackModifier);
        //}

        //player.SetVelocityX(playerData.attackVelocity);


    }

    public override void Exit()
    {
        base.Exit();

        lightAttack = false;
        attackModifier = 0;
        //player.Animator.SetInteger("attackModifier", attackModifier);
        player.Animator.SetBool("lightAttack", lightAttack);
        player.sword.ExitSword();
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

    //public override void AnimationTrigger()
    //{
    //    base.AnimationTrigger();

    //    player.sword.CheckMeleeAttack();
    //}





}
