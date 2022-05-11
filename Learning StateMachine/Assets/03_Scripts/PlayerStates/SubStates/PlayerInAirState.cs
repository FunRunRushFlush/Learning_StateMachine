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

        if (sprintInput)
        {
            sprintJump = true;
        }



            //Debug.Log("Sprint Jump works inAir " + sprintJump);
        }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log("sprint Jump inAir "+sprintJump);


        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        sprintInput = player.InputHandler.SprintInput;

        attackLightInput = player.InputHandler.AttackLightInput;
        attackHardInput = player.InputHandler.AttackHardInput;
        defendInput = player.InputHandler.DefendInput;
        backdashInput = player.InputHandler.BackdashInput;
        canBackdash = player.InputHandler.CanBackdash;
        specialAttack = player.InputHandler.SpecialInput;
        canSpecialAttack = player.InputHandler.CanSpecial;


        //Debug.Log("attackLightInput"+attackLightInput);

        if (attackLightInput)
        {
            stateMachine.ChangeState(player.AttackLightState);
        }
        else if (attackHardInput)
        {
            stateMachine.ChangeState(player.AttackHardState);
        }
        else if (isGrounded && player.CurrentVelocity.y < 0.02f)
        {
            sprintJump = false;
            stateMachine.ChangeState(player.LandState);

        }
        else if (!isGrounded)
        {
            if (sprintJump)
            {
                //Debug.Log("im in SprintJumpmode");
                player.SetVelocityX(playerData.runVelocity * xInput);

                player.Animator.SetFloat("yVelocity", player.CurrentVelocity.y);
                player.Animator.SetFloat("xVelocity", player.CurrentVelocity.x * player.FacingDirection);
            }
            else if(!sprintJump)
            {
                player.SetVelocityX(playerData.walkVelocity * xInput);

                player.Animator.SetFloat("yVelocity", player.CurrentVelocity.y);
                player.Animator.SetFloat("xVelocity", player.CurrentVelocity.x * player.FacingDirection);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
