using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkState : PlayerGroundMovementState
{
    public PlayerWalkState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        player.SetVelocityX(playerData.walkVelocity * xInput);

      
        if (sprintInput)
        {
            stateMachine.ChangeState(player.RunState);
        }
        if ( xInput != player.FacingDirection)
        {
            stateMachine.ChangeState(player.BackwardsState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
