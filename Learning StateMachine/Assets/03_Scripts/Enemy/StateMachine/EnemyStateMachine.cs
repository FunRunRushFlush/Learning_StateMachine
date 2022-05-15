using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{ 
    public State currentState { get; private set; }

    public void Initialize(State staringState)
    {
        currentState = staringState;
        currentState.Enter();
    }
    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();

    }
}
