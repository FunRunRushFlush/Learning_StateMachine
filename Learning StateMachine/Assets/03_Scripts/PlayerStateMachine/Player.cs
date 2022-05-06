using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    #region Grounded_SubStates
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerBackwardsState BackwardsState { get; private set; }

    #endregion



    public PlayerInputHandler InputHandler{ get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody2D RB { get; private set; }

    public PlayerData playerData;


    public Vector2 CurrentVelocity { get; private set; }
    public int FacingDirection { get; private set; }
    private Vector2 workspace;


    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        WalkState = new PlayerWalkState(this, StateMachine, playerData, "walk");
        RunState = new PlayerRunState(this, StateMachine, playerData, "run");
        BackwardsState = new PlayerBackwardsState(this, StateMachine, playerData, "backward");

    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
        FacingDirection = 1;
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity; 
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void CheckIfShouldFlip(int xInput)
    {
        if(xInput != 0 && xInput != FacingDirection)
        {
            Flip();
        }
    }
    private void Flip()
    {
        FacingDirection *= -1;
        transform.Rotate(0f, 180.0f, 0f);
    }
}
