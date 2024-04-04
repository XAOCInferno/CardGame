using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class eRelationshipTypes
{

    public const byte Owned = 0;
    public const byte Enemy = 1;
    public const byte Allied = 2;

}

public class CardDataInScene : MonoBehaviour
{

    private int _OwnedByPlayer = new();
    public int OwnedByPlayer { get => _OwnedByPlayer; set => _OwnedByPlayer = value; }

    private CardInfo _CardBlueprint;
    public CardInfo CardBlueprint { get => _CardBlueprint; set => _CardBlueprint = value; }



}
