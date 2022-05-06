using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHardState : PlayerAbilityState
{
    private bool hardAttack;
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
        attackModifier = 0;
        yInput = player.InputHandler.NormInputY;

        player.Animator.SetInteger("attackModifier", attackModifier);
        player.Animator.SetBool("hardAttack", hardAttack);

        Debug.Log("Im in AttackState");
        if (yInput == -1)
        {
            attackModifier = 2;
            player.Animator.SetInteger("attackModifier", attackModifier);
        }

        player.SetVelocityX(playerData.attackVelocity);


    }

    public override void Exit()
    {
        base.Exit();

        hardAttack = false;
        attackModifier = 0;
        player.Animator.SetInteger("attackModifier", attackModifier);
        player.Animator.SetBool("hardAttack", hardAttack);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();



        

        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}
