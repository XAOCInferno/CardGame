using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckDataInScene : MonoBehaviour
{

    private int _OwnerPlayerID;
    public int OwnerPlayerID { get => _OwnerPlayerID; set => _OwnerPlayerID = value; }


    private DeckInfo _DeckBlueprint;
    public DeckInfo DeckBlueprint { get => _DeckBlueprint; set => _DeckBlueprint = value; }

}
