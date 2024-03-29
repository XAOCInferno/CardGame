using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : DynamicEnvironmentObject
{
    private float MovementRate = 0.03f;
    private Vector3 CurrentMovementDirection = new();

    private void OnEnable()
    {

        Actions.OnMovementInput += HandlePlayerMovement;

    }

    private void OnDisable()
    {

        Actions.OnMovementInput -= HandlePlayerMovement;

    }

    private void HandlePlayerMovement(Vector3 movementDirection)
    {

        CurrentMovementDirection = movementDirection;

    }

    private void Update()
    {

        OrderPositionChange(GetOffsetOfLocalPosition(CurrentMovementDirection * MovementRate), eMovementTypes.Hard, timeToTravel:null);

    }

}
