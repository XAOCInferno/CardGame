using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private GameObject CardPrefab;
    private Dictionary<int, CardObject> AllCardObjectsByID = new();

    private void OnEnable()
    {

        Actions.OnGenerateCardObject += SetupCardData;
        Actions.OnAddNewPlayer += SetupPlayerCardData;

    }

    private void OnDisable()
    {

        Actions.OnGenerateCardObject -= SetupCardData;
        Actions.OnAddNewPlayer -= SetupPlayerCardData;

    }

    private void SetupCardData(int ID, CardObject newCardObject)
    {

        AllCardObjectsByID.Add(ID, newCardObject);

    }

    private void SetupPlayerCardData(PlayerInfo targetPlayer)
    {

        for(int i = 0; i < targetPlayer.Deck.CardsInDeck.Count; i++) 
        {

            Instantiate(CardPrefab, new Vector3(100,0,0),new(),transform);

        }

    }

}
