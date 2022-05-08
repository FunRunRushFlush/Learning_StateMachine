using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityX(0f);
       
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        player.SetVelocityX(0f);

        if (!isExitingStates)
        {
            if (xInput != 0 && !sprintInput)
            {
                if (xInput == player.FacingDirection)
                {
                    stateMachine.ChangeState(player.WalkState);
                }
                else if (xInput != player.FacingDirection)
                {
                    stateMachine.ChangeState(player.BackwardsState);
                }
            }
            else if (xInput != 0 && sprintInput)
            {
                stateMachine.ChangeState(player.RunState);
            }
            else if (yInput == -1)
            {
                stateMachine.ChangeState(player.CrouchIdleState);
            }
            else if (backdashInput)
            {
                Debug.Log("YEAH");
                stateMachine.ChangeState(player.BackdashState);
            }
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
