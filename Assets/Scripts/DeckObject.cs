using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckObject : InteractableObject
{

    [SerializeField] private DeckObjectView View;
    [SerializeField] private DeckController Controls;

    protected override void OnEnable()
    {

        Actions.OnChangeFocusedItem += OrderSelectionStatusChange;
        _OnEnable();

    }

    protected override void OnDisable()
    {

        Actions.OnChangeFocusedItem -= OrderSelectionStatusChange;
        _OnDisable();

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