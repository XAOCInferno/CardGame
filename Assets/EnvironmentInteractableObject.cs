using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentInteractableObject : InteractableObject
{

    protected override void OnEnable()
    {

        _OnEnable();

    }

    protected override void OnDisable()
    {

        _OnDisable();

    }

    protected override void OnSelected()
    {


    }

    protected override void OnDeSelected()
    {


    }


}
