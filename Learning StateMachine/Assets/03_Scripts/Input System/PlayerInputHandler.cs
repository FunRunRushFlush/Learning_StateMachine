using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public float inputHoldTime = 0.2f; //how long the Jump input will be true
    private float jumpInputStartTime;


    private void Update()
    {
        CheckJumpInputHoldTime();
        //CheckDashInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);

        NormMovementInput = new Vector2(NormInputX, NormInputY);
        //Debug.Log(RawMovementInput);

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

}
