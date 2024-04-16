using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectCacher 
{
    private static int CurrentUniqueID = 0;
    private static List<int> RecycledIDs = new();
    private static Dictionary<int, CachedObject> AllCachedObjects = new();


    //Simply generate a new ID
    public static int CacheObject(CachedObject self)
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

        Dbg.Log(eLogType.Info, eLogVerbosity.Simple, "Caching new object: " + self.name + ", Giving ID: " + CurrentUniqueID);
        AllCachedObjects.Add(returnID, self);

        return returnID;

    }

    public static void DeCacheObject(int objectCachedID)
    {

        AllCachedObjects.Remove(objectCachedID);
        RecycledIDs.Add(objectCachedID);

    }

    public static CachedObject GetCachedObject(int objectCachedID)
    {
        
        if(AllCachedObjects.ContainsKey(objectCachedID) == false)
        {

            Dbg.Log(eLogType.Error, eLogVerbosity.Full, "Cached object with ID of: " + objectCachedID + " does not exist! Returning null.");

            return null;

        }

        return AllCachedObjects[objectCachedID];

    }

}
