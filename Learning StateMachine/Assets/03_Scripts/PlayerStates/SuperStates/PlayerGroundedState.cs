using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 rawInput;    // all sub States have acces to this variable
    protected Vector2 normInput;    // all sub States have acces to this variable
    protected int xInput;       // all sub States have acces to this variable
    protected int yInput;       // all sub States have acces to this variable
    protected bool sprintInput; // all sub States have acces to this variable
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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

        xInput = player.InputHandler.NormInputX;
        yInput = player.InputHandler.NormInputY;
        sprintInput = player.InputHandler.SprintInput;

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
