using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MarkerObject : CachedObject
{
    [SerializeField] private eMarkerTypes MarkerType;
    [SerializeField] private int Player;

    #region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(MarkerObject))]
    public class MarkerObjectEditor : Editor 
    {
        public override void OnInspectorGUI()
        {
            if (Application.isPlaying == true) return; 
            base.OnInspectorGUI();

            MarkerObject marker = (MarkerObject)target;
            if (marker.MarkerType == eMarkerTypes.MainDeckStartLocation)
            {

                DrawMainDeckSettings(marker);

            }
        }

        static void DrawMainDeckSettings(MarkerObject marker)
        {

            EditorGUILayout.BeginHorizontal();

            marker.Player = Mathf.Clamp(marker.Player, 1, 2);

            marker.gameObject.name = MarkerProvider.GenerateMarkerName(marker.MarkerType, marker.Player.ToString());

            EditorGUILayout.EndHorizontal();

        }
    }
#endif
    #endregion

    protected void OnEnable()
    {

        CacheSelf();
        MarkerProvider.AddMarkerToDictionary(name, this);

    }

    protected void OnDisable()
    {

        DeCacheSelf();
        MarkerProvider.RemoveMarker(name);

    }

    public void ChangeMarkerName(string newName)
    {

        MarkerProvider.RemoveMarker(name);
        gameObject.name = newName;
        MarkerProvider.AddMarkerToDictionary(name, this);

    }

}
