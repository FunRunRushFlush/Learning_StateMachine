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

        if (JumpInput)
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.JumpState);
        }
        else if (attackLightInput)
        {
            stateMachine.ChangeState(player.AttackLightState);
        }
        else if(attackHardInput)
        {
            stateMachine.ChangeState(player.AttackHardState);
        }
        else if(defendInput)
        {
            stateMachine.ChangeState(player.DefendState);
        }
        else if (backdashInput)
        {
            stateMachine.ChangeState(player.BackdashState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
