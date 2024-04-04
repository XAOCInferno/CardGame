using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class eCardStates
{

    public const byte InDeck = 0;
    public const byte InHand = 1;

}

public class CardObject : InteractableObject
{

    [SerializeField] private DynamicEnvironmentObject _ParentEnvironmentalObject;
    public DynamicEnvironmentObject ParentEnvironmentalObject { get => _ParentEnvironmentalObject; set => _ParentEnvironmentalObject = value; }

    [SerializeField] private CardObjectView _View;
    public CardObjectView View { get => _View; set => _View = value; }

    [SerializeField] private byte _CardState = eCardStates.InDeck;
    public byte CardState { get => _CardState; set => _CardState = value; }

    [SerializeField] private CardDataInScene _CardData;
    public CardDataInScene CardData { get => _CardData; set => _CardData = value; }

    protected override void OnEnable()
    {

        Actions.OnChangeFocusedItem += OrderSelectionStatusChange;

        _OnEnable();

        Actions.OnGenerateCardObject.InvokeAction(ID, this);

    }

    protected override void OnDisable()
    {

        Actions.OnChangeFocusedItem -= OrderSelectionStatusChange;

        _OnDisable();

        Actions.OnDestroyCardObject.InvokeAction(ID);

    }

    private void OrderSelectionStatusChange()
    {

        _View.DoChangeSelectionStatus(SelectedStatus);

    }

    override protected void OnSelected()
    {

        _View.DoChangeSelectionStatus(SelectedStatus);

    }

    override protected void OnDeSelected()
    {

        _View.DoChangeSelectionStatus(SelectedStatus);

    }

}
