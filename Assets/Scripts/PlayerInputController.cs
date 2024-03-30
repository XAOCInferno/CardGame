using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

        float valueAsFloat = value.Get<float>();
        bool isUp = false;

        if(valueAsFloat == 0)
        {
            isUp = true;
        }

        Actions.OnPlayerClick.InvokeAction(isUp);

    }

}
