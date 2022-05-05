using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    protected PlayerStateMachine _ctx;
    protected PlayerStateFactory _factory;
    public PlayerBaseState(PlayerStateMachine currentContext, PlayerStateFactory playerStateFactory) 
    {
        _ctx = currentContext;
        _factory = playerStateFactory;
    }


    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();
    public abstract void InitializeSubStates();

    void UpdateStates() { }
    protected void SwitchState(PlayerBaseState newState) 
    {   // Exits current State
        ExitState();
        // New State enter
        newState.EnterState();
        // switch current state of_ctx (contex)
        _ctx.CurrentPlayerState = newState;
    }
    protected void SetSuperState() { }
    protected void SetSubState() { }





}
