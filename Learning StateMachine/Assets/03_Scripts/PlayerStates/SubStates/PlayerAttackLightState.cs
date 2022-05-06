using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackLightState : PlayerAbilityState
{
    
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

        lightAttack = false;
        attackModifier = 0;
        player.Animator.SetInteger("attackModifier", attackModifier);
        player.Animator.SetBool("lightAttack", lightAttack);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

      

        player.SetVelocityX(playerData.attackVelocity);

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
