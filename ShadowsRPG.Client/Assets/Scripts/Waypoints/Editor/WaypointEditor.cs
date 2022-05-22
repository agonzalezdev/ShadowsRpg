using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Waypoint))]
public class NewBehaviourScript : Editor
{
    Waypoint WaypointTarget => target as Waypoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.red;
        if (WaypointTarget.Points == null)
            return;

        for (int i = 0; i < WaypointTarget.Points.Length; i++)
        {
            //Enable change check
            EditorGUI.BeginChangeCheck();
            var currentPoint = WaypointTarget.CurrentPosition + WaypointTarget.Points[i];

            //Create handle
            var newPoint = Handles.FreeMoveHandle(
                currentPoint, 
                Quaternion.identity,
                0.7f,
                new Vector3(0.3f, 0.3f, 0.3f),
                Handles.SphereHandleCap
            );

            //Create label
            var text = new GUIStyle();
            text.fontStyle = FontStyle.Bold;
            text.fontSize = 16;
            text.normal.textColor = Color.black;
            var textAlignment = Vector3.down * 0.3f + Vector3.right * 0.3f;
            Handles.Label(
                WaypointTarget.CurrentPosition + WaypointTarget.Points[i] + textAlignment,
                $"{i + 1}",
                text
            );

            //Check for changes again
            if (EditorGUI.EndChangeCheck()){
                Undo.RecordObject(target, "Free Move Handle");
                WaypointTarget.Points[i] = newPoint - WaypointTarget.CurrentPosition;
            }
        }
    }
}
