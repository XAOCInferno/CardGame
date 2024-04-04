using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : CachedObject
{

    private void OnEnable()
    {

        self = this;
        CacheSelf();

    }

    private void OnDisable()
    {

        DeCacheSelf();

    }

    public void DisableSelf()
    {

        gameObject.SetActive(false);

    }

}
