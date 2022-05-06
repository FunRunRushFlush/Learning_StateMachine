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



    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();

        NormInputX = Mathf.RoundToInt(RawMovementInput.x);
        NormInputY = Mathf.RoundToInt(RawMovementInput.y);

        NormMovementInput = new Vector2(NormInputX, NormInputY);
        //Debug.Log(RawMovementInput);
        Debug.Log(NormMovementInput);
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump Input started");
        }
        if (context.performed)
        {
            Debug.Log("Jump Input performed");
        }
        if (context.canceled)
        {
            Debug.Log("Jump Input canceled");
        }
    }
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
}
