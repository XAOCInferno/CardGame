using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectCacher 
{
    private static int CurrentUniqueID = 0;
    private static List<int> RecycledIDs = new();

    //Simply generate a new ID
    public static int CacheObject()
    {
        int returnID;

        if (RecycledIDs.Count > 0)
        {

            returnID = RecycledIDs[0];
            RecycledIDs.RemoveAt(0);

        }
        else
        {

            returnID = CurrentUniqueID;

            CurrentUniqueID++;

            if (CurrentUniqueID == 2147483647)
            {

                Dbg.Log(eLogType.Error, eLogVerbosity.Full, "Cached IDs have reached the maximum! Resetting back to 0. This could cause errors and should never happen!");
                CurrentUniqueID = 0;

            }

        }

        return returnID;

    }

    public static void DeCacheObject(int objectCachedID)
    {

        RecycledIDs.Add(objectCachedID);

    }
}
