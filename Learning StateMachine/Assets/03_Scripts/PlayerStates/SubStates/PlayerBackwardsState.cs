using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackwardsState : PlayerGroundedState
{
    public PlayerBackwardsState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        player.SetVelocityX(playerData.backwardsVelocity * xInput);

        if (!sprintInput)
        {
            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            if (xInput != 0 && xInput == player.FacingDirection)
            {
                stateMachine.ChangeState(player.WalkState);
            }
        }
        else if(sprintInput)
        {
            if(xInput !=0)
            {
                stateMachine.ChangeState(player.RunState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
