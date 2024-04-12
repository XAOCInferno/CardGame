using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerManager : MonoBehaviour
{

    private Dictionary<Enum, GameObject> MarkerPrefabsFromEnum = new();

    [Serializable] public struct EnumObject
    {

        public eMarkerTypes MarkerType;
        public GameObject MarkerPrefab;

    }

    [SerializeField] private EnumObject[] ExposedMarkerPrefabsFromEnum;

    private void OnEnable()
    {

        foreach(EnumObject prefabHolder in ExposedMarkerPrefabsFromEnum)
        {

            MarkerPrefabsFromEnum.Add(prefabHolder.MarkerType, prefabHolder.MarkerPrefab);

        }

        Actions.ForceGenerateNewMarker += GenerateNewMarker;

    }

    private void OnDisable()
    {

        MarkerPrefabsFromEnum.Clear();

        Actions.ForceGenerateNewMarker -= GenerateNewMarker;

    }

    private void GenerateNewMarker(Enum markerType, string newMarkerID)
    {

        Instantiate(MarkerPrefabsFromEnum[markerType], new Vector3(), new Quaternion(), transform).gameObject.name = newMarkerID;

    }
}
