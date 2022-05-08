using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    
    public PlayerInAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckIfGrounded();
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

        xInput = player.InputHandler.NormInputX;
        attackLightInput = player.InputHandler.AttackLightInput;
        attackHardInput = player.InputHandler.AttackHardInput;
        defendInput = player.InputHandler.DefendInput;
        Debug.Log("attackLightInput"+attackLightInput);
       
        if(attackLightInput)
        {
            stateMachine.ChangeState(player.AttackLightState);
        }
        else if(attackHardInput)
        {
            stateMachine.ChangeState(player.AttackHardState);
        }
        else if(isGrounded && player.CurrentVelocity.y < 0.02f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else 
        {
            player.SetVelocityX(playerData.walkVelocity * xInput);

            player.Animator.SetFloat("yVelocity", player.CurrentVelocity.y);
            player.Animator.SetFloat("xVelocity", player.CurrentVelocity.x * player.FacingDirection);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
