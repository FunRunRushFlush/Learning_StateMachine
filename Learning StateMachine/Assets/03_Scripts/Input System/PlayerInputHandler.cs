using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 RawMovementInput { get; private set; }
    public Vector2 NormMovementInput { get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputY { get; private set; }


    public bool SprintInput { get; private set; }
    public bool AttackLightInput { get; private set; }
    public bool AttackHardInput { get; private set; }
    public bool DefendInput { get; private set; }

    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }
    public bool BackdashInput { get; private set; }


    public float inputHoldTime = 0.2f; //how long the Jump input will be true
    private float jumpInputStartTime;

    private Vector2 workspace;

    private Vector2 NeutralVec,UpVec, UpRightVec, RightVec, DownRightVec, DownVec, DownLeftVec, LeftVec, UpLeftVec;

    public List<FightInputs> recentInputs = new List<FightInputs>();

    public List<FightInputs> specialInputs;
    public List<FightInputs> backdashInputs;
    public List<FightInputs> fillerInputs;
    #region InputDirection
    public enum FightInputs { Neutral,Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft, Filler }

    private int lastInput;



    #endregion

    private void Awake()
    {
        NeutralVec = new Vector2(0, 0);
        UpVec  = new Vector2(0, 1);
        UpRightVec  = new Vector2(1, 1);
        RightVec  = new Vector2(1, 0);
        DownRightVec  = new Vector2(1, -1);
        DownVec  = new Vector2(0, -1);
        DownLeftVec  = new Vector2(-1, -1);
        LeftVec  = new Vector2(-1, 0);
        UpLeftVec  = new Vector2(-1, 1);

        recentInputs.AddRange(fillerInputs);
    }

    private void Update()
    {
        CheckJumpInputHoldTime();
        CheckBackdashInput();
        CheckSpecialInput();


        
        //CheckDashInputHoldTime();

    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);

        //NormMovementInput = new Vector2(NormInputX, NormInputY);
        workspace = Vector2Int.RoundToInt(RawMovementInput.normalized);
        NormMovementInput = workspace.normalized;
        if (workspace == NeutralVec)
        {
            lastInput = (int)recentInputs.Last();

            if (lastInput != (int)FightInputs.Neutral)
            {
                recentInputs.Add(FightInputs.Neutral);
            }
        }
        else if (workspace == UpVec)
        {
            lastInput = (int)recentInputs.Last();
            if (lastInput != (int)FightInputs.Up)
            {
                recentInputs.Add(FightInputs.Up);
            }
        }
        else if(workspace == UpRightVec)
        {
            lastInput = (int)recentInputs.Last();
            if (lastInput != (int)FightInputs.UpRight)
            {
                recentInputs.Add(FightInputs.UpRight);
            }
        }
        else if (workspace == RightVec)
        {
            lastInput = (int)recentInputs.Last();
            if (lastInput != (int)FightInputs.Right)
            {
                recentInputs.Add(FightInputs.Right);
            }
        }
        else if (workspace == DownRightVec)
        {
            lastInput = (int)recentInputs.Last();
            if (lastInput != (int)FightInputs.DownRight)
            {
                recentInputs.Add(FightInputs.DownRight);
            }
        }
        else if (workspace == DownVec)
        {
            lastInput = (int)recentInputs.Last();
            if (lastInput != (int)FightInputs.Down)
            {
                recentInputs.Add(FightInputs.Down);
            }
        }
        else if (workspace == DownLeftVec)
        {
            lastInput = (int)recentInputs.Last();
            if (lastInput != (int)FightInputs.DownLeft)
            {
                recentInputs.Add(FightInputs.DownLeft);
            }
        }
        else if (workspace == LeftVec)
        {
            lastInput = (int)recentInputs.Last();
            if (lastInput != (int)FightInputs.Left)
            {
                recentInputs.Add(FightInputs.Left);
            }
        }
        else if (workspace == UpLeftVec)
        {
            lastInput = (int)recentInputs.Last();
            if (lastInput != (int)FightInputs.UpLeft)
            {
                recentInputs.Add(FightInputs.UpLeft);
            }
        }



    }
    //Ich hätte [OnJumpInput()] wie beim Sprit Button gemacht aber Bardent meint es könnte Probleme geben, wenn die StateMachine nicht so schnell in JumpState swichten könnte
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            JumpInputStop = false;
            jumpInputStartTime = Time.time;
            Debug.Log("Jump Input");
        }

        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnAttackLightInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackLightInput = true;
        }

        if (context.canceled)
        {
            AttackLightInput = false;
        }
    }
    public void OnAttackHardInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackHardInput = true;
        }

        if (context.canceled)
        {
            AttackHardInput = false;
        }
    }
        public void OnDefendInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            DefendInput = true;
        }

        if (context.canceled)
        {
            DefendInput = false;
        }
    }
    public void UseJumpInput() => JumpInput = false;
    public void OnSprintInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SprintInput = true;
        }

        if (context.canceled)
        {
            SprintInput = false;
        }
    }

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

    public void CheckSpecialInput()
    {
        for (int i = recentInputs.Count - 1, j = specialInputs.Count - 1;  j>=0 ; i--, j--)
        {

            FightInputs input = recentInputs[i];

            FightInputs nextspecialInputs = specialInputs[j];

            if (input != nextspecialInputs)
            {

                break;

            }
            else if (j == 0)
            {
                Debug.Log("Special Move Activated");
                recentInputs.Clear();
                recentInputs.AddRange(fillerInputs);


            }
        }
    }
    public void CheckBackdashInput()
    {
        for (int i = recentInputs.Count - 1, j = backdashInputs.Count - 1; j >= 0; i--, j--)
        {

            FightInputs input = recentInputs[i];

            FightInputs nextspecialInputs = backdashInputs[j];

            if (input != nextspecialInputs)
            {
                BackdashInput = false;
                break;

            }
            else if (j == 0)
            {
                
                
                recentInputs.AddRange(fillerInputs);
                BackdashInput = true;

            }
        }
    }
}
