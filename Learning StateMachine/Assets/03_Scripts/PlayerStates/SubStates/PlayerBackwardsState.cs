using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackwardsState : PlayerGroundMovementState
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
            if (xInput == player.FacingDirection)
            {
                stateMachine.ChangeState(player.WalkState);
            }
        }
        else if(sprintInput)
        {          
            stateMachine.ChangeState(player.RunState);   
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
