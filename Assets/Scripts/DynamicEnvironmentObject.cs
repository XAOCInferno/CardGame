using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public static class eMovementTypes
{

    public const byte Smooth = 0;
    public const byte Hard = 1;
    public const byte Stepped = 2;

}

public class DynamicEnvironmentObject : EnvironmentObject
{

    private Vector3 targetLocalPosition;
    private Vector3 targetLocalScale;

    public Vector3 GetOffsetOfLocalPosition(Vector3? offset)
    {
        
        if (offset == null)
        {

            Dbg.Log(eLogType.Error, eLogVerbosity.Full, "Cannot get position offset from self, offset is null!");
            return transform.localPosition;

        }

        return new Vector3(transform.localPosition.x + offset.Value.x, transform.localPosition.y + offset.Value.y, transform.localPosition.z + offset.Value.z);
    
    }

    public void OrderPositionChange(Vector3? newTargetPosition, byte? travelType, float? timeToTravel)
    {

        if (newTargetPosition == null)
        {

            Dbg.Log(eLogType.Error, eLogVerbosity.Full, "Cannot move object as target position is null!");
            return;

        }

        targetLocalPosition = newTargetPosition.Value;

        if (travelType == null)
        {

            SetPosition();

        }
        else
        {

            switch (travelType)
            {

                case eMovementTypes.Smooth:

                    LerpToPosition(timeToTravel);
                    break;

                case eMovementTypes.Hard:

                    SetPosition();
                    break;

                default:

                    SetPosition();
                    break;

            }

        }

    }

    public void OrderScaleChange(Vector3? newTargetScale, byte? scaleType, float? timeToScale)
    {
        if (newTargetScale == null)
        {

            Dbg.Log(eLogType.Error, eLogVerbosity.Full, "Cannot scale object as target scale is null!");
            return;

        }

        targetLocalScale = newTargetScale.Value;

        if (scaleType == null)
        {

            SetPosition();

        }
        else
        {

            switch (timeToScale)
            {

                case eMovementTypes.Smooth:

                    LerpToScale(timeToScale);
                    break;

                case eMovementTypes.Hard:

                    SetScale();
                    break;

                default:

                    SetScale();
                    break;

            }

        }

    }

    private void SetPosition() => transform.position = targetLocalPosition;
    private void SetScale() => transform.localScale = targetLocalScale;

    private void LerpToPosition(float? timeToTravel)
    {
        if(timeToTravel == null) 
        {

            Dbg.Log(eLogType.Warning, eLogVerbosity.Full, "Cannot smoothly move without a travel rate, defaulting to a hard move.");
            SetPosition();

            return;

        }

        StartCoroutine(LerpToPositionCoroutine(timeToTravel.Value));

    }

    private void LerpToScale(float? timeToScale)
    {
        if (timeToScale == null)
        {

            Dbg.Log(eLogType.Warning, eLogVerbosity.Full, "Cannot smoothly scale without a scale rate, defaulting to a hard scale.");
            SetScale();

            return;

        }

        StartCoroutine(LerpToScaleCoroutine(timeToScale.Value));

    }


    //This needs to be moved into a physics update
    IEnumerator LerpToPositionCoroutine(float timeToTravel)
    {

        float moveRate = 0.05f;
        float movePerTick = timeToTravel * moveRate;

        for (float travelPercent = 0f; travelPercent < 1; travelPercent += movePerTick)
        {

            transform.position = Vector3.Lerp(transform.position, targetLocalPosition, Mathf.Min(travelPercent, 1));

            yield return new WaitForSeconds(moveRate); //Replace "WaitForSeconds" with some kind of internal clock

        }

    }

    //This needs to be moved into a physics update
    IEnumerator LerpToScaleCoroutine(float timeToScale)
    {

        float scaleRate = 0.05f;
        float scalePerTick = timeToScale * scaleRate;

        for (float scalePercent = 0f; scalePercent < 1; scalePercent += scaleRate)
        {

            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale, Mathf.Min(scalePercent, 1));

            yield return new WaitForSeconds(scaleRate); //Replace "WaitForSeconds" with some kind of internal clock

        }
        
    }

}
