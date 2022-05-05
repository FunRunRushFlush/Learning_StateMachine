using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }

    private Vector2 _workspace;
    public override void EnterState()
    {
        Debug.Log("Im in PlayerJumpState ");
        Jump();
    }
    public override void UpdateState() { }
    public override void ExitState() { }
    public override void CheckSwitchStates() { }
    public override void InitializeSubStates() { }

    private void Jump()
    {
        _ctx.SetVelocityY();
    }
}
