using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetableUI : CachedObject, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {

        Dbg.Log(eLogType.Info, eLogVerbosity.Full, "Hovering over UI: " + name);
        PlayerInputControllerState.MouseIsOverUI = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        Dbg.Log(eLogType.Info, eLogVerbosity.Full, "No longer hovering over UI: " + name);
        PlayerInputControllerState.MouseIsOverUI = false;

    }
}
