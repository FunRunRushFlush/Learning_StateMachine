using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialState : PlayerAbilityState
{
    
    
    public PlayerSpecialState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        player.InputHandler.UseSpecialImput();

        
        attackModifier = 0;
        yInput = player.InputHandler.NormInputY;

        player.Animator.SetInteger("attackModifier", attackModifier);
        

        Debug.Log("Im in SpecialState");


        player.SetVelocityX(playerData.attackVelocity);


    }

    public override void Exit()
    {
        base.Exit();

        
        attackModifier = 0;
        player.Animator.SetInteger("attackModifier", attackModifier);
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();



        player.SetVelocityX(playerData.attackVelocity);
        if (!isExitingStates)
        {

            if (isAnimationFinished)
            {
                player.InputHandler.UseSpecialImput();
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }


}

