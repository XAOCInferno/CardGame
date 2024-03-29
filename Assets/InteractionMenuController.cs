using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenuController : MonoBehaviour
{

    [SerializeField] private GameObject TargetMenu;
    [SerializeField] private bool IsOpen = false;

    private float MenuOpenStatus;

    private void OnEnable()
    {

        if (IsOpen)
        {

            MenuOpenStatus = 1;
            TargetMenu.SetActive(true);

        }
        else
        {

            MenuOpenStatus = 0;
            TargetMenu.SetActive(false);

        }

    }


    public void OpenMenu()
    {
        if (!IsOpen)
        {

            TargetMenu.SetActive(true);
            IsOpen = true;

        }

    }

    public void CloseMenu()
    {

        if (IsOpen)
        {

            TargetMenu.SetActive(false);
            IsOpen = false;

        }

    }
}
