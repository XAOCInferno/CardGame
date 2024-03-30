using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CardInfo", order = 1)]
public class CardInfo : ScriptableObject
{

    public string Name;
    public string Description;

    public int DrawCardsOnUse;
    public int DrawCardsOnDraw;
    public int DrawCardsOnAdd;

    public int DrawCardsOnUseOpponent;
    public int DrawCardsOnDrawOpponent;
    public int DrawCardsOnAddOpponent;

    public int DiscardCardsOnUse;
    public int DiscardCardsOnDraw;
    public int DiscardCardsOnAdd;

    public int DiscardCardsOnUseOpponent;
    public int DiscardCardsOnDrawOpponent;
    public int DiscardCardsOnAddOpponent;

}
