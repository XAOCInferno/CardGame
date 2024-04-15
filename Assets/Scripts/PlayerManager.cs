using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] private GameObject PlayerPrefab;
    [SerializeField] private PlayerInfo[] AllPlayerInfo;

    private Dictionary<int, PlayerObject> AllPlayersByID = new();
    
    private void OnEnable()
    {

        Invoke(nameof(AddNewPlayers),1); //This should not be an invoke, consider a better way of deploying these objects so that it happens at the correct time.

    }

    private void AddNewPlayers()
    {

        for(int i = 0; i < AllPlayerInfo.Length; i++)
        {

            PlayerObject newPlayer = CreateNewBlankPlayerObject();
            int newID = newPlayer.InitialPlayerSetup(AllPlayerInfo[i], (byte) (AllPlayersByID.Count + 1));
            AllPlayersByID.Add(newID, newPlayer);

            ReassignDeckSpawnMarkerName(newPlayer);

            Actions.OnAddNewPlayer.InvokeAction(newID);
            Actions.OnSetupBlankDeck.InvokeAction(AllPlayersByID[newID].Info.Deck.CardsInDeck.Count);
            Actions.OnPopulatePlayerDeck(newID, AllPlayersByID[newID].Info.Deck);

        }

        //Action: send command to organise the card info. This will use a blank card and replace its data where required. Then this card is sorted in the deck manager with player id

    }

    private void ReassignDeckSpawnMarkerName(PlayerObject newPlayer)
    {

        string ExpectedMarkerName = MarkerProvider.GenerateMarkerName(eMarkerTypes.MainDeckStartLocation, newPlayer.PlayerNumber.ToString());
        string DesiredMarkerName = MarkerProvider.GenerateMarkerName(eMarkerTypes.MainDeckStartLocation, newPlayer.ID.ToString());

        MarkerProvider.ChangeMarkerName(eMarkerTypes.MainDeckStartLocation, ExpectedMarkerName, DesiredMarkerName);

    }

    private PlayerObject CreateNewBlankPlayerObject()
    {

        return Instantiate(PlayerPrefab, new Vector3(100, 0, 0), new(), transform).GetComponent<PlayerObject>();

    }

}
