using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : LevelController
{
    private void OnEnable()
    {

        Actions.OnLevelLoadComplete += SetupBoard;

    }

    private void OnDisable()
    {

        Actions.OnLevelLoadComplete -= SetupBoard;

    }

    private void SetupBoard()
    {

        Actions.OnBoardSetupBegin.InvokeAction();

        Dbg.Log(eLogType.Info, eLogVerbosity.Full, "Setting up the board.");

        Actions.OnBoardSetupComplete.InvokeAction();

        Dbg.Log(eLogType.Info, eLogVerbosity.Full, "Setting up the board has completed.");

    }

}
