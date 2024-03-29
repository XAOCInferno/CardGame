using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardObjectView : MonoBehaviour
{

    [SerializeField] private Material DefaultMaterial;
    [SerializeField] private Material HoverMaterial;
    [SerializeField] private Material SelectedMaterial;
    [SerializeField] private Material SelectedHoverMaterial;
    [SerializeField] private MeshRenderer TargetMeshRenderer;

    [SerializeField] private InteractionMenuController InteractionMenu;

    public void ChangeCardSelectionStatus(byte hoverStatus)
    {

        UpdateMaterial(hoverStatus);
        UpdateInteractionMenu(hoverStatus);

    }

    private void UpdateMaterial(byte hoverStatus)
    {
        switch (hoverStatus)
        {

            case eSelectionTypes.None:

                TargetMeshRenderer.sharedMaterial = DefaultMaterial;
                break;

            case eSelectionTypes.Hover:

                TargetMeshRenderer.sharedMaterial = HoverMaterial;
                break;

            case eSelectionTypes.Selected:

                TargetMeshRenderer.sharedMaterial = SelectedMaterial;
                break;

            case eSelectionTypes.SelectedHover:

                TargetMeshRenderer.sharedMaterial = SelectedHoverMaterial;
                break;

            default:

                Dbg.Log(eLogType.Warning, eLogVerbosity.Full, "Invalid hoverStatus of: " + hoverStatus + ". Cannot change card view!");
                TargetMeshRenderer.sharedMaterial = DefaultMaterial;
                break;

        }        

    }

    private void UpdateInteractionMenu(byte hoverStatus)
    {

        if(hoverStatus == eSelectionTypes.Hover ||
           hoverStatus == eSelectionTypes.Selected ||
           hoverStatus == eSelectionTypes.SelectedHover)
        {

            InteractionMenu.OpenMenu();

        }
        else
        {

            InteractionMenu.CloseMenu();

        }

    }

}
