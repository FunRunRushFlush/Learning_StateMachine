using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    public int attackModifier;

    public PlayerAbilityState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        isAbilityDone = false; 
        
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

        attackLightInput = player.InputHandler.AttackLightInput;
        attackHardInput = player.InputHandler.AttackHardInput;
        defendInput = player.InputHandler.DefendInput;
        backdashInput = player.InputHandler.BackdashInput;
        canBackdash = player.InputHandler.CanBackdash;
        specialAttack = player.InputHandler.SpecialInput;
        canSpecialAttack = player.InputHandler.CanSpecial;

        if (isAbilityDone)
        {
            if(isGrounded && player.CurrentVelocity.y < 0.1f)
            {
                sprintJump = false;
                stateMachine.ChangeState(player.IdleState);
            }
            else 
            {
                stateMachine.ChangeState(player.InAirState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
