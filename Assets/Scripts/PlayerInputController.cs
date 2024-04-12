using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputController : MonoBehaviour
{
    private Vector3 MoveDirection = new();

    public void OnMove(InputValue value)
    {

        Vector3 moveDirection = value.Get<Vector3>();
        MoveDirection = moveDirection;
        Actions.OnMovementInput.InvokeAction(moveDirection);

    }

    public void OnClick(InputValue value)
    {

        bool isUp = GetIfClickIsUp(value);
        Actions.OnPlayerClick.InvokeAction(isUp, PlayerInputControllerState.MouseIsOverUI);

    }

    private bool GetIfClickIsUp(InputValue value)
    {

        float valueAsFloat = value.Get<float>();

        if (valueAsFloat == 0)
        {

            return true;

        }

        return false;

    }

}
