using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public static class eSelectionTypes
{

    public const byte None = 0;
    public const byte Hover = 1;
    public const byte Selected = 2;
    public const byte SelectedHover = 3;

}

[RequireComponent(typeof(Collider))]
public abstract class InteractableObject : MonoBehaviour
{

    [SerializeField] private Collider _CollisionObject;
    public Collider CollisionObject { get => _CollisionObject; set => _CollisionObject = value; }

    private byte _SelectedStatus = eSelectionTypes.None;
    public byte SelectedStatus { get => _SelectedStatus; set => _SelectedStatus = value; }


    protected abstract void OnEnable();
    protected abstract void OnDisable();

    protected void _OnDisable() => Actions.OnPlayerClick -= UpdateSelectionStatus;

    protected void _OnEnable()
    {

        if (_CollisionObject == null)
        {

            _CollisionObject = GetComponent<Collider>();

        }

        Actions.OnPlayerClick += UpdateSelectionStatus;

    }

    private void OnMouseEnter()
    {

        Dbg.Log(eLogType.Info,eLogVerbosity.Full, "Hovering over: " + name);
        SetFocusedItem(_CollisionObject);

    }

    private void OnMouseExit()
    {

        Dbg.Log(eLogType.Info, eLogVerbosity.Full, "No longer hovering over: " + name);
        SetFocusedItem(null);

    }

    protected abstract void OnSelected();
    protected abstract void OnDeSelected();

    private void SetFocusedItem(Collider newCollisionObject)
    {

        RaycastProvider.CurrentTargetedCollider = newCollisionObject;

        if (newCollisionObject == CollisionObject)
        {

            switch (SelectedStatus)
            {
                case eSelectionTypes.None:

                    SelectedStatus = eSelectionTypes.Hover;
                    break;

                case eSelectionTypes.Selected:

                    SelectedStatus = eSelectionTypes.SelectedHover;
                    break;

                default:

                    return;

            }

        }
        else
        {
            switch (SelectedStatus)
            {

                case eSelectionTypes.Hover:

                    SelectedStatus = eSelectionTypes.None;
                    break;

                case eSelectionTypes.SelectedHover:

                    SelectedStatus = eSelectionTypes.Selected;
                    break;

                default:

                    return;

            }

        }

        Actions.OnChangeFocusedItem.InvokeAction();

    }

    private void UpdateSelectionStatus(bool IsClickUp)
    {
        if (!IsClickUp) { return; }

        if (SelectedStatus == eSelectionTypes.Hover)
        {

            SelectedStatus = eSelectionTypes.SelectedHover;
            OnSelected();

        }
        else if(SelectedStatus == eSelectionTypes.Selected)
        {

            SelectedStatus = eSelectionTypes.None;
            OnDeSelected();

        }

    }

}
