using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{


    private bool JumpInput;
    
    
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        yInput = player.InputHandler.NormInputY;
        sprintInput = player.InputHandler.SprintInput;
        JumpInput = player.InputHandler.JumpInput;
        attackLightInput = player.InputHandler.AttackLightInput;
        attackHardInput = player.InputHandler.AttackHardInput;
        defendInput = player.InputHandler.DefendInput;
        backdashInput = player.InputHandler.BackdashInput;
        canBackdash = player.InputHandler.CanBackdash;
        specialAttack = player.InputHandler.SpecialInput;
        canSpecialAttack = player.InputHandler.CanSpecial;

        if (JumpInput)
        {
            if (sprintInput)
            {
                sprintJump = true;
                Debug.Log("SprintJump tree" + sprintJump);
                player.InputHandler.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }
            else if(!sprintInput)
            {
                sprintJump = false;
                player.InputHandler.UseJumpInput();
                stateMachine.ChangeState(player.JumpState);
            }
        }
        else if(specialAttack && canSpecialAttack)
        {
            stateMachine.ChangeState(player.SpecialState);
        }
        else if (!specialAttack)
        {
            if (attackLightInput)
            {
                stateMachine.ChangeState(player.AttackLightState);
            }
            else if (attackHardInput)
            {
                stateMachine.ChangeState(player.AttackHardState);
            }
            else if (defendInput)
            {
                stateMachine.ChangeState(player.DefendState);
            }
        }
        else if (!isGrounded && player.CurrentVelocity.y<0)
        {
            stateMachine.ChangeState(player.InAirState);
        }
 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
