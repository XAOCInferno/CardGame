using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PlayerInfo", order = 1)]
public class PlayerInfo : ScriptableObject
{

    public string Name;
    public string Description;
    public Sprite PlayerImage;
    public DeckInfo Deck;

}
