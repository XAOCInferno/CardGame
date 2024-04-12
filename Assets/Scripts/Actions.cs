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

    public static Action<Vector3> OnMovementInput; //Vector3: Direction of movement
    public static Action OnChangeFocusedItem;

    public static Action<bool, bool> OnPlayerClick; //Bool: true = mouse button up, false = mouse button down | Bool: Is click on a UI element?

    public static Action<int, CardObject> OnGenerateCardObject; //Int: ID of card to generate | CardObject: Card to generate
    public static Action<int, DeckObject> OnGenerateDeckObject; //Int: ID of card to generate | DeckObject: Deck to generate
    public static Action<int> OnDestroyCardObject; //Int: ID of card to destroy
    public static Action<int> OnDestroyDeckObject; //Int: ID of card to generate | CardObject: Deck to generate
    public static Action<Enum, string> ForceGenerateNewMarker; //Enum: Marker type | string: name of the marker to generate its unique ID

    public static Action<int> OnDrawCard; //Int: Number of cards to draw
    public static Action<CardObject, Vector3> OnAddCardToHand; //CardObject: Card to add to hand | Vector3: Position to teleport card to (eg: the top of the deck)

    public static Action<int> OnAddNewPlayer; //Int: UniqueID for the player
    public static Action<int> OnSetupBlankDeck; //Int: Size of deck
    public static Action<int, DeckInfo> OnPopulatePlayerDeck; //Int: Player ID | int: number of player in game | DeckInfo: Information on the deck the player is using
    public static Action<int, int> OnAssignDeckToPlayer; //Int: Player ID | Int: Number of cards in deck
    public static Action<int, List<int>> OnSetCardsToPlayer; //Int: Player ID | Lit<Int>: All the Card IDs
    //public static Action<int, int> OnSetDeckToPlayer; //Int: Player ID | Int: Deck ID

    public static Action<int, CardInfo> OnAssignCardBlueprint; //Int: Card ID to change | CardInfo: Info for the card


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


