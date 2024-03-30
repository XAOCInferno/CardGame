using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileController : MonoBehaviour
{

    private List<TileObject> AllTileObjects = new();

    private void OnEnable()
    {

        Actions.OnRegisterTileObject += RegisterNewTile;
        Actions.OnDeRegisterTileObject += DeRegisterTile;

    }

    private void OnDisable()
    {

        Actions.OnDeRegisterTileObject -= RegisterNewTile;
        Actions.OnDeRegisterTileObject -= DeRegisterTile;

    }

    private void RegisterNewTile(TileObject newTileObject)
    {

        AllTileObjects.Add(newTileObject);

        Vector3 newTilePosition = new (Random.Range(-5, 5), Random.Range(-0.5f, 2), Random.Range(-5, 5));
        float newTileTimeToMove = Random.Range(1.5f, 4f);

        Vector3 newTileScale = new (Random.Range(1, 5), Random.Range(1f, 5), Random.Range(1, 5));
        float newTileTimeToScale = Random.Range(1f, 4f);

        newTileObject.SetupTileObjectTransform(newTilePosition, newTileTimeToMove, newTileScale, newTileTimeToScale);

    }

    private void DeRegisterTile(TileObject oldTileObject)
    {

        AllTileObjects.Remove(oldTileObject);
        Destroy(oldTileObject.gameObject); //Does this need to be moved to some kind of manager?

    }

}
