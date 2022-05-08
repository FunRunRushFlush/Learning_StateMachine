using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerGroundMovementState
{
    public PlayerRunState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        player.SetVelocityX(playerData.runVelocity * xInput);

        player.CheckIfShouldFlip(xInput);

        if (!isExitingStates)
        {
            if (!sprintInput)
            {
                stateMachine.ChangeState(player.WalkState);
            }
        }
      
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
