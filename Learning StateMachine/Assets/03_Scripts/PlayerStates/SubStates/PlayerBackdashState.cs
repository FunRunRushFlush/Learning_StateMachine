using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackdashState : PlayerGroundedState
{
    public PlayerBackdashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
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

        player.SetVelocityXY(playerData.dashVelocityX, playerData.dashVelocityY);

        if(isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
