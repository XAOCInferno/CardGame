using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CachedObject : MonoBehaviour
{

    //The topmost class must define itself as "self"
    protected dynamic self;

    private int _ID;
    public int ID { get => _ID; set => _ID = value; }

    protected void CacheSelf()
    {

        _ID = ObjectCacher.CacheObject(this);

    }

    protected void DeCacheSelf()
    {

        ObjectCacher.DeCacheObject(ID);

    }

}
