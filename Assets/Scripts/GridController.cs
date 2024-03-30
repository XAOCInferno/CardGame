using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : BoardController
{

    [SerializeField] private GameObject TilePrefab;

    private void OnEnable()
    {

        Actions.OnBoardSetupComplete += SetupGrid;

    }

    private void OnDisable()
    {

        Actions.OnBoardSetupComplete -= SetupGrid;

    }

    public void SetupGrid()
    {
        Vector2Int gridDimmensions = new(4, 4);
        //Get Grid Dimmensions Here

        int totalTiles = gridDimmensions.x * gridDimmensions.y;

        if(totalTiles == 0)
        {

            Dbg.Log(eLogType.Error, eLogVerbosity.Full, "Cannot create grid, grid dimmensions size of 0!");
            return;

        }

        for(int newTileNumber = 0; newTileNumber < totalTiles; newTileNumber++)
        {

            Instantiate(TilePrefab, transform.localPosition, transform.localRotation, transform);

        }

    }

}
