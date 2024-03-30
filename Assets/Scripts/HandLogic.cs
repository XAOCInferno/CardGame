using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLogic : MonoBehaviour
{

    [SerializeField] private Vector3 FirstCardPositionInHand;
    [SerializeField] private Vector3 PositionOffsetPerCard;
    private int positionOffset;
    private Dictionary<int, DynamicEnvironmentObject> AllCardEnvironmentObjects = new();

    private void OnEnable()
    {

        Actions.OnAddCardToHand += AddNewCardToHand;

    }

    private void OnDisable()
    {

        Actions.OnAddCardToHand -= AddNewCardToHand;

    }

    private void AddNewCardToHand(CardObject cardToAdd, Vector3 sentFromPosition)
    {

        cardToAdd.ParentEnvironmentalObject.OrderPositionChange(sentFromPosition, eMovementTypes.Hard, 0);
        AllCardEnvironmentObjects.Add(cardToAdd.ID, cardToAdd.ParentEnvironmentalObject);

        SetAllCardPositions();

    }

    private void SetAllCardPositions()
    {

        Vector3 nextCardPosition = AllCardEnvironmentObjects.Count * PositionOffsetPerCard / 2;

        for (int i = 0; i < AllCardEnvironmentObjects.Count; i++)
        {

            AllCardEnvironmentObjects[i].OrderPositionChange(nextCardPosition, eMovementTypes.Smooth, 2);
            nextCardPosition += PositionOffsetPerCard;

        }

    }

}
