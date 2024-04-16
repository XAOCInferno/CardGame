using System;
using System.Collections;
using System.Collections.Generic;

public enum eMarkerTypes
{

    Generic = 0,
    MainDeckStartLocation = 1,
    HandPosition = 2

}

public static class MarkerProvider 
{
    
    public static Dictionary<Enum, string> MarkerNamesFromEnum = new()
    { 
        {eMarkerTypes.Generic, "Mkr_Generic" }, 
        {eMarkerTypes.MainDeckStartLocation, "Mkr_MainDeckStartLocation" },
        {eMarkerTypes.HandPosition, "Mkr_HandPosition" }
    };

    private static Dictionary<string, MarkerObject> MarkersAsDictionary = new();

    public static void AddMarkerToDictionary(string newMarkerID, MarkerObject newMarker)
    {

        if (MarkerExists(newMarkerID))
        {

            Dbg.Log(eLogType.Error, eLogVerbosity.Full, "Marker with ID: " + newMarkerID + " already exists! Overwriting old marker.");
            MarkersAsDictionary[newMarkerID] = newMarker;

        }
        else
        {

            Dbg.Log(eLogType.Info, eLogVerbosity.Full, "Adding Marker to data, ID: " + newMarkerID);
            MarkersAsDictionary.Add(newMarkerID, newMarker);

        }

    }

    public static MarkerObject GetMarker(string markerID)
    {

        if (MarkerExists(markerID))
        {

            return MarkersAsDictionary[markerID];

        }
        else
        {

            Dbg.Log(eLogType.Error, eLogVerbosity.Full, "Marker with ID: " + markerID + " dies not exist!");
            return null;

        }

    }

    public static void RemoveMarker(string markerID)
    {

        MarkersAsDictionary.Remove(markerID);

    }

    public static void EnsureMarkerExists(Enum markerType, string markerID)
    {

        if (MarkerExists(markerID) == false)
        {

            CreateMarker(markerType,markerID);

        }

    }

    private static void CreateMarker(Enum markerType, string markerID)
    {

        Actions.ForceGenerateNewMarker(markerType, markerID);

    }

    public static bool MarkerExists(string markerID)
    {

        if (MarkersAsDictionary.ContainsKey(markerID))
        {

            return true;

        }

        return false;

    }

    public static bool ChangeMarkerName(Enum markerType, string oldMarkerName, string newMarkerName)
    {

        MarkerObject tmpMarker = GetMarker(oldMarkerName);

        if (tmpMarker == null)
        {

            CreateMarker(markerType, newMarkerName);
            return false;

        }

        tmpMarker.ChangeMarkerName(newMarkerName);
        return true;

    }

    public static string GenerateMarkerName(Enum markerType, string markerName)
    {

        if(MarkerNamesFromEnum.ContainsKey(markerType) == false)
        {

            MarkerNamesFromEnum.Add(markerType, "[REALTIME GENERATED]: " + markerName);

        }

        return MarkerNamesFromEnum[markerType] + markerName;

    }

}
