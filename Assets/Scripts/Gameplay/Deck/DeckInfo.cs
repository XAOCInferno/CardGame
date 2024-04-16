using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DeckInfo", order = 1)]
public class DeckInfo : ScriptableObject
{

    public List<CardInfo> CardsInDeck = new();

}
