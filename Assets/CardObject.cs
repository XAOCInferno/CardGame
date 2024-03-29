using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : InteractableObject
{

    [SerializeField] private CardObjectView view;

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

        view.ChangeCardSelectionStatus(SelectedStatus);

    }

    override protected void OnSelected()
    {

        view.ChangeCardSelectionStatus(SelectedStatus);

    }

    override protected void OnDeSelected()
    {

        view.ChangeCardSelectionStatus(SelectedStatus);

    }


}
