using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private void OnEnable()
    {

        Actions.OrderLevelLoad += LoadLevelData;

    }

    private void OnDisable()
    {

        Actions.OrderLevelLoad -= LoadLevelData;

    }

    private void LoadLevelData()
    {

        Actions.OnLevelLoadBegin.InvokeAction();

        Dbg.Log(eLogType.Info, eLogVerbosity.Full, "Loading the level data.");

        Actions.OnLevelLoadComplete.InvokeAction();

        Dbg.Log(eLogType.Info, eLogVerbosity.Full, "Loading the level data has completed.");

    }

}
