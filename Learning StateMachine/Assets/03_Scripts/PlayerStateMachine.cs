using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public Vector2 rawMovementInput { get; private set; }
    private int NormInputX;
    private int NormInputY;
    public float xInput;
    public float yInput;

    private bool _isJumpingPressed;
    private bool _isCrouching;

    public float _yJumpVelocity = 15f;
    public float _walkVelocity = 6f;
    public bool IsJumpingPressed { get { return _isJumpingPressed; } set { _isJumpingPressed = value; } }
    public bool IsCrouching { get { return _isCrouching; } set { _isCrouching = value; } }

    PlayerBaseState _currentPlayerState;
    public PlayerBaseState CurrentPlayerState { get { return _currentPlayerState; } set { _currentPlayerState = value; } }
    public PlayerStateFactory _states;
    //public PlayerJumpState JumpState = new PlayerJumpState();
    //public PlayerWalkState WalkState = new PlayerWalkState();
    //public PlayerCrouchingState CrouchingState = new PlayerCrouchingState();
    //public PlayerIdleState IdleState = new PlayerIdleState();

    public Rigidbody2D _rb;
    public Collider2D _collider2D;
    public Animator _animator;

    public int FacingDirection { get; private set; }

    public bool CanSetVelocity { get; set; }

    public Vector2 CurrentVelocity { get; private set; }
    private Vector2 workspace;




    private void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _states = new PlayerStateFactory(this);
        _currentPlayerState = _states.Grounded();
        _currentPlayerState.EnterState();
        

        FacingDirection = 1;
        CanSetVelocity = true;
    }
    private void Start()
    {
        //_currentPlayerState = IdleState;

        //_currentPlayerState.EnterState(this);
    }

    private void Update()
    {
        GetMovementInput();
        GetJumpInput();
        GetCrouchingInput();
        _currentPlayerState.UpdateState();



        //_currentPlayerState.UpdateState(this);
    }

    public void SwitchState(PlayerBaseState state)
    {
        //_currentPlayerState = state;
        //state.EnterState(this);
    }

    #region ALL_GetMovementInputs
    private void GetMovementInput() 
    {

        rawMovementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        NormInputX = Mathf.RoundToInt(rawMovementInput.x);
        NormInputY = Mathf.RoundToInt(rawMovementInput.y);
        xInput = NormInputX;
        yInput = NormInputY;

        Debug.Log("Move Input Pressed");
    }
    private void GetJumpInput()
    {
        if(Input.GetButtonDown("Jump"))
        {
            _isJumpingPressed = true;
            Debug.Log("Jump Input Pressed");
        }
        else if(Input.GetButtonUp("Jump"))
        {
            _isJumpingPressed = false;
            Debug.Log("Jump Input Canceled");
        }

    }
    private void GetCrouchingInput()
    {
        if(yInput==-1)
        {
            _isCrouching = true;
            Debug.Log("isCrouching"+ _isCrouching);
        }
        else
        {
            _isCrouching = false;
            Debug.Log("isCrouching" + _isCrouching);
        }
    }
    #endregion

    #region Apply Movement
    public void SetVelocityZero()
    {
        workspace = Vector2.zero;
        SetFinalVelocity();
    }
    //public void SetVelocity(float velocity, Vector2 angle, int direction)
    //{
    //    angle.Normalize();
    //    workspace.Set(angle.x * velocity * direction, angle.y * velocity);
    //    SetFinalVelocity();
    //    Debug.Log("Angle WallJump");
    //}

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workspace = direction * velocity;
        SetFinalVelocity();
    }
    public void SetVelocityX()
    {
        workspace.Set(_walkVelocity, CurrentVelocity.y);
        SetFinalVelocity();
    }
    public void SetVelocityY()
    {
        workspace.Set(CurrentVelocity.x, _yJumpVelocity);
        SetFinalVelocity();
    }

    private void SetFinalVelocity()
    {
        if (CanSetVelocity)
        {
            _rb.velocity = workspace;
            CurrentVelocity = workspace;

        }
    }

    #endregion
}
