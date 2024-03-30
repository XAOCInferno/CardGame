using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachedObject : MonoBehaviour
{
    private int _ID;
    public int ID { get => _ID; set => _ID = value; }

    protected void CacheSelf()
    {

        _ID = ObjectCacher.CacheObject();

    }

    protected void DeCacheSelf()
    {

        ObjectCacher.DeCacheObject(ID);

    }

}
