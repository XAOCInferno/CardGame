using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    /// <summary>
    /// To continue this I need to change how the flow of cards works.
    /// We need a way of working out which player owns which cards.
    /// The cards currently have their data generated then object registered.
    /// By the time the object is registered, we lose track of their player.
    /// Is it bad to simply send the player data through to the card so that it makes it to the deck manager or can we reorgnaise flow?
    /// </summary>

    //private Dictionary<int, List<int>> DeckIDsByPlayerID = new();
    private Dictionary<PlayerInfo, List<int>> CardIDsByPlayerInfo = new();

    private void OnEnable()
    {

        Actions.OnAddNewPlayer += AddPlayerInfoDictionaryEntry;
        //Actions.OnAssignCardController += AddCardIDToDictionaryEntry;

    }

    private void OnDisable()
    {

        Actions.OnAddNewPlayer -= AddPlayerInfoDictionaryEntry;
        //Actions.OnAssignCardController -= AddCardIDToDictionaryEntry;

    }

    private void DrawCards()
    {
        //Draw

    }

    private void AddPlayerInfoDictionaryEntry(PlayerInfo newPlayer)
    {

        CardIDsByPlayerInfo.Add(newPlayer, new());

    }

    private void AddCardIDToDictionaryEntry(PlayerInfo newPlayer, int cardID)
    {

        CardIDsByPlayerInfo[newPlayer].Add(cardID);

    }

}