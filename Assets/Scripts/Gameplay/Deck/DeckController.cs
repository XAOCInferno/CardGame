using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{

    [SerializeField] private int _LinkedDeckID;
    public int LinkedDeckID { get => _LinkedDeckID; set => _LinkedDeckID = value; }

    public void DrawACard()
    {

        Actions.OnDrawCard.InvokeAction(_LinkedDeckID, 1);

    }

}
