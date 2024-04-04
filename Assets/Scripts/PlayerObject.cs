using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : EnvironmentObject
{

    private PlayerInfo _Info;
    public PlayerInfo Info { get => _Info; set => _Info = value; }

    protected void OnEnable()
    {

        CacheSelf();

    }

    protected void OnDisable()
    {

        DeCacheSelf();

    }

    public int InitialPlayerSetup(PlayerInfo newInfo)
    {

        _Info = newInfo;
        return ID;

    }

}
