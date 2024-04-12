using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    [SerializeField] private GameObject DeckPrefab;

    private Dictionary<int, List<int>> CardIDsByPlayerID = new();
    private Dictionary<int, DeckObject> AllDeckObjectsByID = new();
    private List<int> UnusedDecksByID = new();


    private void OnEnable()
    {

        Actions.OnAddNewPlayer += AddPlayerInfoDictionaryEntry;
        Actions.OnPopulatePlayerDeck += PopulateDeck;
        Actions.OnSetCardsToPlayer += AddCardIDsToPlayer;
        Actions.OnGenerateDeckObject += SetupDeckDetails;
        Actions.OnDrawCard += DrawCards;

    }

    private void OnDisable()
    {

        Actions.OnAddNewPlayer -= AddPlayerInfoDictionaryEntry;
        Actions.OnPopulatePlayerDeck -= PopulateDeck;
        Actions.OnSetCardsToPlayer -= AddCardIDsToPlayer;
        Actions.OnGenerateDeckObject -= SetupDeckDetails;
        Actions.OnDrawCard -= DrawCards;

    }

    private void DrawCards(int numberOfCards)
    {
        //Draw
        Dbg.Log(eLogType.Info, eLogVerbosity.Simple, "Attempting to draw " + numberOfCards);
    }

    private void AddPlayerInfoDictionaryEntry(int newPlayerID)
    {

        CardIDsByPlayerID.Add(newPlayerID, new());

    }

    private void AddCardIDsToPlayer(int newPlayerID, List<int> cardIDs)
    {

        CardIDsByPlayerID[newPlayerID] = cardIDs;

    }

    private void PopulateDeck(int playerID, DeckInfo deck)
    {

        CreateBlankDeckForPlayer(playerID);
        AssignBlankDecksToPlayer(playerID); 
        Actions.OnAssignDeckToPlayer.InvokeAction(playerID, deck.CardsInDeck.Count);

        for(int i = 0; i < CardIDsByPlayerID[playerID].Count; i++)
        {

            Actions.OnAssignCardBlueprint.InvokeAction(CardIDsByPlayerID[playerID].ElementAt(i), deck.CardsInDeck[i]);

        }

    }

    private void CreateBlankDeckForPlayer(int playerNumber)
    {

        Vector3 DeckLocation = new();
        MarkerObject TargetMarker = MarkerProvider.GetMarker(MarkerProvider.GenerateMarkerName(eMarkerTypes.MainDeckStartLocation, playerNumber.ToString()));

        if(TargetMarker != null)
        {

            DeckLocation = TargetMarker.transform.position;

        }

        Instantiate(DeckPrefab, DeckLocation, new(), transform);

    }

    private void SetupDeckDetails(int ID, DeckObject newDeckObject)
    {

        AllDeckObjectsByID.Add(ID, newDeckObject);
        UnusedDecksByID.Add(ID);

    }

    private void AssignBlankDecksToPlayer(int playerID)
    {
        //This probably doesn't need to be an event unless we need to inform the player manager
        //Actions.OnSetDeckToPlayer.InvokeAction(playerID, UnusedDecksByID[0]);
        //AllDeckObjectsByID[UnusedDecksByID[0]];
        UnusedDecksByID.RemoveAt(0);

    }

}
