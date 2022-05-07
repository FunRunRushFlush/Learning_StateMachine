using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefendState : PlayerAbilityState
{
    public PlayerDefendState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        //player.SetVelocityX(playerData.attackVelocity);
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.SetVelocityX(playerData.attackVelocity);

        if (!defendInput)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
