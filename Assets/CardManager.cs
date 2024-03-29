using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    private List<CardObject> AllCardObjects = new();
    private Dictionary<Collider, int> CardObjectIDByColliders = new();

    private CardObject GetCardObjectFromCollider(Collider targetedCollider)
    {
        return AllCardObjects[CardObjectIDByColliders[targetedCollider]];
    }

}
