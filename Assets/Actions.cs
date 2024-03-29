using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public static class Actions
{

    public static Action OrderLevelLoad; //Replace this later with generic flow
    public static Action OnLevelLoadBegin;
    public static Action OnLevelLoadComplete;

    public static Action OnBoardSetupBegin;
    public static Action OnBoardSetupComplete;

    public static Action<TileObject> RegisterTileObject;
    public static Action<TileObject> DeRegisterTileObject;

    public static Action<UnityEngine.Vector3> OnMovementInput;
    public static Action OnChangeFocusedItem;

    public static Action<bool> OnPlayerClick;

}

public static class ActionExtensions
{

    public static bool InvokeAction(this Action self)
    {

        if (self == null)
        {

            DoActionInvokedFailedMessage();
            return false;

        }

        self();
        return true;

    }

    public static bool InvokeAction<A>(this Action<A> self, A arg1)
    {

        if (self == null)
        {

            DoActionInvokedFailedMessage();
            return false;

        }

        self(arg1);
        return true;

    }

    public static bool InvokeAction<A, B>(this Action<A, B> self, A arg1, B arg2)
    {

        if (self == null)
        {

            DoActionInvokedFailedMessage();
            return false;

        }

        self(arg1, arg2);
        return true;

    }

    public static bool InvokeAction<A, B, C>(this Action<A, B, C> self, A arg1, B arg2, C arg3)
    {

        if (self == null)
        {

            DoActionInvokedFailedMessage();
            return false;

        }

        self(arg1, arg2, arg3);
        return true;

    }

    public static bool InvokeAction<A, B, C, D>(this Action<A, B, C, D> self, A arg1, B arg2, C arg3, D arg4)
    {

        if (self == null)
        {

            DoActionInvokedFailedMessage();
            return false;

        }

        self(arg1, arg2, arg3, arg4);
        return true;

    }

    private static void DoActionInvokedFailedMessage()
    {

        Dbg.Log(eLogType.Warning, eLogVerbosity.Full, "Cannot call an action that has no subscribers!");

    }

}


