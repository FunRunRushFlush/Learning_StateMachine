using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHardState : PlayerAbilityState
{
    public bool hardAttack;
    public PlayerAttackHardState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        hardAttack = true;
        attackModifier = 3;

        player.sword.EnterSword();
        //yInput = player.InputHandler.NormInputY;

        //player.Animator.SetInteger("attackModifier", attackModifier);
        //player.Animator.SetBool("hardAttack", hardAttack);

        
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



    }

    public override void Exit()
    {
        base.Exit();

        hardAttack = false;
        attackModifier = 0;
        player.Animator.SetInteger("attackModifier", attackModifier);
        player.Animator.SetBool("hardAttack", hardAttack);
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


}
