using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }
   
    #region All StateMachine States
    #region Grounded_SubStates
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkState WalkState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerBackwardsState BackwardsState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public PlayerCrouchIdleState CrouchIdleState { get; private set; }
    public PlayerCrouchMoveState CrouchMoveState { get; private set; }
    public PlayerBackdashState BackdashState { get; private set; }



    #endregion


    #region Ability_SubStates
    public PlayerAttackLightState AttackLightState { get; private set; }
    public PlayerAttackHardState AttackHardState { get; private set; }
    public PlayerDefendState DefendState { get; private set; }
    public PlayerSpecialState SpecialState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    #endregion

    public PlayerInAirState InAirState { get; private set; }





    #endregion
    #region CheckTransform
    public Transform groundCheck;

    #endregion





    public PlayerData playerData;
    public PlayerInputHandler InputHandler{ get; private set; }
    public Animator Animator { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }

    public PlayerInventory Inventory { get; private set; }


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
        BackdashState = new PlayerBackdashState(this, StateMachine, playerData, "backdash");
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "inAir");
        InAirState = new PlayerInAirState(this, StateMachine, playerData, "inAir");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");
        CrouchIdleState = new PlayerCrouchIdleState(this, StateMachine, playerData, "crouchIdle");
        CrouchMoveState = new PlayerCrouchMoveState(this, StateMachine, playerData, "crouchMove");
        AttackLightState = new PlayerAttackLightState(this, StateMachine, playerData, "attack");
        AttackHardState = new PlayerAttackHardState(this, StateMachine, playerData, "attack");
        DefendState = new PlayerDefendState(this, StateMachine, playerData, "defend");
        SpecialState = new PlayerSpecialState(this, StateMachine, playerData, "specialAttack");


}
    

    private void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
        MovementCollider = GetComponent<BoxCollider2D>();

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
    public void SetVelocityZero()
    {
        workspace.Set(0, 0);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void SetVelocityY(float velocity)
    {
        workspace.Set(CurrentVelocity.x, velocity);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }
    public void SetVelocityXY(float velocityX,float velocityY)
    {
        workspace.Set(velocityX, velocityY);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetColliderHeight(float height)
    {
        Vector2 center = MovementCollider.offset;
        workspace.Set(MovementCollider.size.x, height);

        if (height > MovementCollider.size.y)
        {
            center.y += (Mathf.Abs(height - MovementCollider.size.y)) / 2;
        }
        else
        {
            center.y -= (Mathf.Abs(height - MovementCollider.size.y)) / 2;
        }

        MovementCollider.size = workspace;
        MovementCollider.offset = center;
    }

    public bool CheckIfGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.groundLayer);


    }



    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();

    private void AnimationFinishedTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();

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
