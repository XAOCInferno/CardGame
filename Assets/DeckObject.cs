using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckObject : InteractableObject
{

    [SerializeField] private DeckObjectView view;

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

        view.DoChangeSelectionStatus(SelectedStatus);

    }

    override protected void OnSelected()
    {

        view.DoChangeSelectionStatus(SelectedStatus);

    }

    override protected void OnDeSelected()
    {

        view.DoChangeSelectionStatus(SelectedStatus);

    }


}
