using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchingState : PlayerBaseState
{
    public PlayerCrouchingState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        Debug.Log("Im in PlayerCrouchingState ");
    }
    public override void UpdateState() { }
    public override void ExitState() { }
    public override void CheckSwitchStates() { }
    public override void InitializeSubStates() { }
}
