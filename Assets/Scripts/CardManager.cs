using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    [SerializeField] private GameObject CardPrefab;
    private Dictionary<int, CardObject> AllCardObjectsByID = new();
    private List<int> UnusedCardsFromID = new();

    private void OnEnable()
    {

        Actions.OnGenerateCardObject += SetupCardData;
        Actions.OnSetupBlankDeck += CreateManyBlankCards;
        Actions.OnAssignDeckToPlayer += SetCardsToPlayer;
        Actions.OnAssignCardBlueprint += AssignCardDetails;
        Actions.OrderAddCardToHand += DoDraw;

    }

    private void OnDisable()
    {

        Actions.OnGenerateCardObject -= SetupCardData;
        Actions.OnSetupBlankDeck -= CreateManyBlankCards;
        Actions.OnAssignDeckToPlayer -= SetCardsToPlayer;
        Actions.OnAssignCardBlueprint -= AssignCardDetails;
        Actions.OrderAddCardToHand -= DoDraw;

    }

    private void SetupCardData(int ID, CardObject newCardObject)
    {

        AllCardObjectsByID.Add(ID, newCardObject);
        UnusedCardsFromID.Add(ID);

    }

    private void CreateManyBlankCards(int newBlankCount)
    {

        for(int i = 0; i < newBlankCount; i++) 
        {

            CreateBlankCard();

        }

    }

    private void CreateBlankCard()
    {

        Instantiate(CardPrefab, new Vector3(100, 0, 0), new(), transform);

    }

    private void AssignCardDetails(int cardID, CardInfo blueprint)
    {

        AllCardObjectsByID[cardID].CardData.CardBlueprint = blueprint;

    }

    private void SetCardsToPlayer(int playerID, int numberOfCards)
    {

        List<int> CardIDsToSend = new();

        for(int i = 0; i < numberOfCards; i++)
        {

            CardIDsToSend.Add(AllCardObjectsByID[UnusedCardsFromID[0]].ID);
            UnusedCardsFromID.RemoveAt(0);

        }

        Actions.OnSetCardsToPlayer(playerID, CardIDsToSend);

    }

    private void DoDraw(int cardToAdd, Vector3 startPosition)
    {

        Actions.OnAddCardToHand.InvokeAction(AllCardObjectsByID[cardToAdd], startPosition);

    }

}
