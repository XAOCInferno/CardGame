using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : CachedObject
{

    public void DisableSelf()
    {

        gameObject.SetActive(false);

    }

}
