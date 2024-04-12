using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : EnvironmentObject
{

    private PlayerInfo _Info;
    public PlayerInfo Info { get => _Info; set => _Info = value; }

    private byte _PlayerNumber;
    public byte PlayerNumber { get => _PlayerNumber; set => _PlayerNumber = value; }

    protected void OnEnable()
    {

        CacheSelf();

    }

    protected void OnDisable()
    {

        DeCacheSelf();

    }

    public int InitialPlayerSetup(PlayerInfo newInfo, byte PlayerNumber)
    {

        _Info = newInfo;
        _PlayerNumber = PlayerNumber;
        return ID;

    }

}
