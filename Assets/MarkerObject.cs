using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MarkerObject : CachedObject
{
    [SerializeField] private eMarkerTypes MarkerType;
    private int Player;

    #region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(MarkerObject))]
    public class MarkerObjectEditor : Editor 
    {
        public override void OnInspectorGUI()
        {
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
            EditorGUILayout.LabelField("Player", GUILayout.MaxWidth(125));
            marker.Player = EditorGUILayout.IntField(marker.Player);

            if(marker.Player < 1)
            {
                marker.Player = 1;
            }
            else if(marker.Player > 2)
            {
                marker.Player = 2;
            }

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
