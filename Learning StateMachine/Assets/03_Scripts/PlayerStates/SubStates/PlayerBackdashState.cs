using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBackdashState : PlayerGroundedState
{
    public PlayerBackdashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }



    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.InputHandler.UseBackdashImput();



    }

    public override void Exit()
    {
        base.Exit();
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityXY(playerData.dashVelocityX * player.FacingDirection * -1, playerData.dashVelocityY);

        if (!isExitingStates)
        {
            if (isAnimationFinished)
            {
                Debug.Log("Backdash Animation Finished");
                //player.InputHandler.UseBackdashImput();
                stateMachine.ChangeState(player.IdleState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
