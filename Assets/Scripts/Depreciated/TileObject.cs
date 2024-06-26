using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : DynamicEnvironmentObject
{

    private void OnEnable()
    {

        Actions.OnRegisterTileObject.InvokeAction(this);
        Actions.OnLevelLoadBegin += DisableSelf;

    }

    private void OnDisable()
    {

        Actions.OnLevelLoadBegin -= DisableSelf;
        Actions.OnDeRegisterTileObject.InvokeAction(this);

    }

    public void SetupTileObjectTransform(Vector3? targetPosition, float? moveRate, Vector3? targetScale, float? scaleRate)
    {

        OrderPositionChange(GetOffsetOfLocalPosition(targetPosition), eMovementTypes.Smooth, moveRate);
        OrderScaleChange(targetScale, eMovementTypes.Smooth, scaleRate);

    }

}
