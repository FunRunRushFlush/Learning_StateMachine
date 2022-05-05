using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory) { }
    public override void EnterState()
    {
        Debug.Log("Im in PlayerRunState ");
    }
    public override void UpdateState() { }
    public override void ExitState() { }
    public override void CheckSwitchStates() { }
    public override void InitializeSubStates() { }
}