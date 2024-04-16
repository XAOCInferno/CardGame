using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandLogic : MonoBehaviour
{

    [SerializeField] private Vector3 FirstCardPositionInHand;
    [SerializeField] private Vector3 PositionOffsetPerCard;
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

        Vector3 nextCardPosition = AllCardEnvironmentObjects.Count/2 * PositionOffsetPerCard / 2;

        foreach (KeyValuePair<int, DynamicEnvironmentObject> pair in AllCardEnvironmentObjects)
        {

            pair.Value.OrderPositionChange(nextCardPosition, eMovementTypes.Smooth, 2);
            nextCardPosition += PositionOffsetPerCard;

        }

    }

}
