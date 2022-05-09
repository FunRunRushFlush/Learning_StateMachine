using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;

public class PlayerInputHandler : MonoBehaviour
{
    public Player Player { get; private set; }

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
    public bool CanBackdash { get; private set; }
    public bool SpecialInput { get; private set; }
    public bool CanSpecial { get; private set; }

    public int NewInputInList { get; private set; }


    public float inputHoldTime = 0.2f; //how long the Jump input will be true
    private float jumpInputStartTime;
    private float backdashStartTime;
    public float backdashCooldown = 10f;
    private float specialStartTime;
    public float specialCooldown = 10f;

    private Vector2 workspace;

    #region FightInput

    private Vector2 NeutralVec,UpVec, UpRightVec, RightVec, DownRightVec, DownVec, DownLeftVec, LeftVec, UpLeftVec;

    public List<FightInputs> recentInputs = new List<FightInputs>();

    public List<FightInputs> specialInputsLeft;
    public List<FightInputs> specialInputsRight;
    public List<FightInputs> backdashInputsLeft;
    public List<FightInputs> backdashInputsRight;
    public List<FightInputs> backdashCancelLeft;
    public List<FightInputs> backdashCancelRight;


    public List<FightInputs> fillerInputs;
    public enum FightInputs { Neutral,Up, UpRight, Right, DownRight, Down, DownLeft, Left, UpLeft, LightAttack, HardAttack, Block }

    private bool backdashCancel;
    private int lastInput;
    private int FaceingDirection;
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

        CanBackdash = true;
        CanSpecial = true;

        NewInputInList = 0;

        Player = GetComponent<Player>();
    }

    private void Update()
    {
        FaceingDirection = Player.FacingDirection;

        CheckListLength();
        CheckJumpInputHoldTime();
        CheckSpecialInput();
        CheckSpecialCooldown();

        CheckBackdashInput();
        CheckBackdashCooldown();
        if (!CanBackdash) 
            { CheckKoreanBackdashCancel();}

        Debug.Log(CanSpecial);

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
    //Ich hätte [OnJumpInput()] wie beim Sprint Button gemacht aber Bardent meint es könnte Probleme geben, wenn die StateMachine nicht so schnell in JumpState swichten könnte
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
            recentInputs.Add(FightInputs.LightAttack);

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
            recentInputs.Add(FightInputs.HardAttack);
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
            recentInputs.Add(FightInputs.Block);
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
    private void CheckListLength()
    {
        if (recentInputs.Count > 27)
        {
            recentInputs.RemoveAt(0);

            NewInputInList++;
        }
    }

    private void CheckJumpInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }
    public void UseSpecialImput()
    {
        Debug.Log("Special Reset Works");
        SpecialInput = false;
        CanSpecial = false;
    }
    public void CheckSpecialCooldown()
    {

        if (Time.time >= specialStartTime + specialCooldown)
        {
            Debug.Log("Special Cooldown Works");
            CanSpecial = true;
        }
    }

    public void CheckSpecialInput()
    {
        if (CanSpecial)
        {
            if (FaceingDirection == 1)
            {
                for (int i = recentInputs.Count - 1, j = specialInputsLeft.Count - 1; j >= 0; i--, j--)
                {

                    FightInputs input = recentInputs[i];
                    FightInputs nextspecialInputsLeft = specialInputsLeft[j];

                    if (input != nextspecialInputsLeft)
                    {
                        break;
                    }
                    else if (j == 0)
                    {
                        Debug.Log("Special Move Activated");
                        //recentInputs.Clear();
                        //recentInputs.AddRange(fillerInputs);
                        SpecialInput = true;
                        specialStartTime = Time.time;
                    }
                }
            }
            else if (FaceingDirection == -1)
            {
                for (int i = recentInputs.Count - 1, j = specialInputsRight.Count - 1; j >= 0; i--, j--)
                {

                    FightInputs input = recentInputs[i];
                    FightInputs nextspecialInputsRight = specialInputsRight[j];

                    if (input != nextspecialInputsRight)
                    {
                        break;
                    }
                    else if (j == 0)
                    {
                        Debug.Log("Special Move Activated");
                        //recentInputs.Clear();
                        //recentInputs.AddRange(fillerInputs);
                        SpecialInput = true;
                        specialStartTime = Time.time;
                    }
                }
            }
        }

    }
    public void UseBackdashImput()
    {
        BackdashInput = false;
        CanBackdash = false;
    }

    private void CheckKoreanBackdashCancel()
    {
        if (FaceingDirection == 1)
        {
            for (int i = recentInputs.Count - 1, j = backdashCancelLeft.Count - 1; j >= 0; i--, j--)
            {

                FightInputs input = recentInputs[i];

                FightInputs nextbackdashCancelLeft = backdashCancelLeft[j];

                if (input != nextbackdashCancelLeft)
                {
                    //BackdashInput = false;
                    break;

                }
                else if (j == 0)
                {
                    backdashCancel = true;
                    Debug.Log("Backdash Cancel Worked");
                }
            }
        }
        else if (FaceingDirection == -1)
        {
            for (int i = recentInputs.Count - 1, j = backdashCancelRight.Count - 1; j >= 0; i--, j--)
            {

                FightInputs input = recentInputs[i];

                FightInputs nextbackdashCancelRight = backdashCancelRight[j];

                if (input != nextbackdashCancelRight)
                {
                    //BackdashInput = false;
                    break;

                }
                else if (j == 0)
                {
                    backdashCancel = true;
                    Debug.Log("Backdash Cancel Worked");

                }
            }
        }
    }
    public void CheckBackdashCooldown()
    {
        if (backdashCancel)
        {
            CanBackdash = true;
        }
        else if(Time.time >= backdashStartTime + backdashCooldown)
        {
            CanBackdash = true;
        }
    }

    public void CheckBackdashInput()
    {
        if (CanBackdash)
        {
            if (FaceingDirection == 1)
            {
                for (int i = recentInputs.Count - 1, j = backdashInputsLeft.Count - 1; j >= 0; i--, j--)
                {

                    FightInputs input = recentInputs[i];

                    FightInputs nextbackdashInputsLeft = backdashInputsLeft[j];

                    if (input != nextbackdashInputsLeft)
                    {
                        //BackdashInput = false;
                        break;

                    }
                    else if (j == 0)
                    {
                        //recentInputs.Clear();
                        //recentInputs.AddRange(fillerInputs);
                        BackdashInput = true;
                        backdashCancel = false;
                        backdashStartTime = Time.time;
                        Debug.Log("Backdash Check works");
                    }
                }
            }
            else if (FaceingDirection == -1)
            {
                for (int i = recentInputs.Count - 1, j = backdashInputsRight.Count - 1; j >= 0; i--, j--)
                {

                    FightInputs input = recentInputs[i];

                    FightInputs nextbackdashInputsRight = backdashInputsRight[j];

                    if (input != nextbackdashInputsRight)
                    {
                        //BackdashInput = false;
                        break;

                    }
                    else if (j == 0)
                    {
                        Debug.Log("Backdash Check works");
                        //recentInputs.Clear();
                        //recentInputs.AddRange(fillerInputs);
                        BackdashInput = true;
                        backdashCancel = false;
                        backdashStartTime = Time.time;

                    }
                }
            }
        }

        
    }

}
