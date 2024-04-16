using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ViewObject : MonoBehaviour
{

    [SerializeField] private Material _DefaultMaterial;
    public Material DefaultMaterial { get => _DefaultMaterial; set => _DefaultMaterial = value; }

    [SerializeField] private Material _HoverMaterial;
    public Material HoverMaterial { get => _HoverMaterial; set => _HoverMaterial = value; }

    [SerializeField] private Material _SelectedMaterial;
    public Material SelectedMaterial { get => _SelectedMaterial; set => _SelectedMaterial = value; }

    [SerializeField] private Material _SelectedHoverMaterial;
    public Material SelectedHoverMaterial { get => _SelectedHoverMaterial; set => _SelectedHoverMaterial = value; }

    [SerializeField] private MeshRenderer _TargetMeshRenderer;
    public MeshRenderer TargetMeshRenderer { get => _TargetMeshRenderer; set => _TargetMeshRenderer = value; }


    [SerializeField] private InteractionMenuController _InteractionMenu;
    public InteractionMenuController InteractionMenu { get => _InteractionMenu; set => _InteractionMenu = value; }

    private void OnEnable()
    {
        
        _TargetMeshRenderer.material = _DefaultMaterial; 

    }

    protected virtual void ChangeSelectionStatus(byte hoverStatus)
    {

        UpdateMaterial(hoverStatus);
        UpdateInteractionMenu(hoverStatus);

    }

    private void UpdateMaterial(byte hoverStatus)
    {
        switch (hoverStatus)
        {

            case eSelectionTypes.None:

                _TargetMeshRenderer.sharedMaterial = _DefaultMaterial;
                break;

            case eSelectionTypes.Hover:

                _TargetMeshRenderer.sharedMaterial = _HoverMaterial;
                break;

            case eSelectionTypes.Selected:

                _TargetMeshRenderer.sharedMaterial = _SelectedMaterial;
                break;

            case eSelectionTypes.SelectedHover:

                _TargetMeshRenderer.sharedMaterial = _SelectedHoverMaterial;
                break;

            default:

                Dbg.Log(eLogType.Warning, eLogVerbosity.Full, "Invalid hoverStatus of: " + hoverStatus + ". Cannot change Mesh Render material!");
                _TargetMeshRenderer.sharedMaterial = _DefaultMaterial;
                break;

        }

    }

    private void UpdateInteractionMenu(byte hoverStatus)
    {

        if (hoverStatus == eSelectionTypes.Hover ||
           hoverStatus == eSelectionTypes.Selected ||
           hoverStatus == eSelectionTypes.SelectedHover)
        {

            _InteractionMenu.OpenMenu();

        }
        else
        {

            _InteractionMenu.CloseMenu();

        }

    }
}
