using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public static class Actions
{

    public static Action OrderLevelLoad; //Replace this later with generic flow
    public static Action OnLevelLoadBegin;
    public static Action OnLevelLoadComplete;

    public static Action OnBoardSetupBegin;
    public static Action OnBoardSetupComplete;

    public static Action<TileObject> OnRegisterTileObject; //OBSOLETE! TileObject: Tile to register
    public static Action<TileObject> OnDeRegisterTileObject; //OBSOLETE! TileObject: Tile to register

    public static Action<UnityEngine.Vector3> OnMovementInput; //Vector3: Direction of movement
    public static Action OnChangeFocusedItem;

    public static Action<bool> OnPlayerClick; //Bool: true = mouse button up, false = mouse button down

    public static Action<int, CardObject> OnGenerateCardObject; //Int: ID of card to generate | CardObject: Card to generate
    public static Action<int> OnDestroyCardObject; //Int: ID of card to destroy
    public static Action<int, CardObject> OnAssignCardController; //Int: ID of card to generate | CardObject: Card to generate

    public static Action<int> OnDrawCard; //Int: Number of cards to draw
    public static Action<CardObject, Vector3> OnAddCardToHand; //CardObject: Card to add to hand | Vector3: Position to teleport card to (eg: the top of the deck)

    public static Action<PlayerInfo> OnAddNewPlayer; //PlayerInfo: The information for the new player added

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


