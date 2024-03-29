using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class eLogType
{

    public const byte Info = 0;
    public const byte Warning = 1;
    public const byte Error = 2;

}

public static class eLogVerbosity
{

    public const byte Full = 0;
    public const byte Simple = 1;

}

public static class Dbg
{

    public static void Log(byte logType, byte logVerbosity, string message)
    {
        message = InterpreteMessage(logVerbosity, message);

        switch (logType)
        {

            case eLogType.Info:

                LogInfo(message);
                break;

            case eLogType.Warning:

                LogWarning(message);
                break;

            case eLogType.Error:

                LogError(message);
                break;

            default:

                break;

        }

    }

    private static string InterpreteMessage(byte logVerbosity, string message)
    {
        string finalMessage;

        switch (logVerbosity)
        {

            case eLogVerbosity.Full:

                finalMessage = message + "\n\n" + Environment.StackTrace;
                break;

            case eLogVerbosity.Simple:

                finalMessage = message;
                break;

            default:

                finalMessage = message;
                break;

        }


        return finalMessage;

    }

    private static void LogInfo(string message)
    {

        Debug.Log(message);
        DumpToFile(message);

    }

    private static void LogWarning(string message)
    {

        Debug.LogWarning(message);
        DumpToFile(message);

    }

    private static void LogError(string message)
    {

        Debug.LogError(message);
        DumpToFile(message);

    }

    private static void DumpToFile(string message)
    {

        //Add this later

    }
}
