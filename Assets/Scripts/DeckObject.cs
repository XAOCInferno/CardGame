using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckObject : InteractableObject
{

    [SerializeField] private DeckObjectView View;
    [SerializeField] private DeckController Controls;

    [SerializeField] private DeckDataInScene _DeckData;
    public DeckDataInScene DeckData { get => _DeckData; set => _DeckData = value; }

    protected override void OnEnable()
    {

        Actions.OnChangeFocusedItem += OrderSelectionStatusChange;

        _OnEnable();

        Actions.OnGenerateDeckObject.InvokeAction(ID, this);

    }

    protected override void OnDisable()
    {

        Actions.OnChangeFocusedItem -= OrderSelectionStatusChange;

        _OnDisable();

        Actions.OnDestroyDeckObject.InvokeAction(ID);

    }

    private void OrderSelectionStatusChange()
    {

        View.DoChangeSelectionStatus(SelectedStatus);

    }

    override protected void OnSelected()
    {

        View.DoChangeSelectionStatus(SelectedStatus);

    }

    override protected void OnDeSelected()
    {

        View.DoChangeSelectionStatus(SelectedStatus);

    }


}
