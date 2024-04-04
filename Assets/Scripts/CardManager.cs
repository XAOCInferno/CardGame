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
        Actions.OnSetupBlankDeck += CreateManyBlankCards;

    }

    private void OnDisable()
    {

        Actions.OnGenerateCardObject -= SetupCardData;
        Actions.OnSetupBlankDeck -= CreateManyBlankCards;

    }

    private void SetupCardData(int ID, CardObject newCardObject)
    {

        AllCardObjectsByID.Add(ID, newCardObject);

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

        Instantiate(CardPrefab, new Vector3(100, 0, 0), new(), transform).GetComponent<CardObject>();

    }

    private void AssignCardDetails(CardObject card, CardInfo blueprint, PlayerInfo ownerPlayer)
    {

        card.CardData.CardBlueprint = blueprint;

    }

}
