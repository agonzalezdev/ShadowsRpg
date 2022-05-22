using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Vector3[] points;
    public Vector3[] Points => points;

    public Vector3 CurrentPosition { get; set; }
    public bool gameIsStarted;

    private void Start()
    {
        gameIsStarted = true;
        CurrentPosition = transform.position;
    }

    public Vector3 GetMovementPosition(int index)
    {
        return CurrentPosition + points[index];
    }

    private void OnDrawGizmos()
    {
        if(!gameIsStarted && transform.hasChanged)
        {
            CurrentPosition = transform.position;
        }

        if (points == null || points.Length == 0)
            return;

        for (int i = 0; i < points.Length; i++)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(points[i] + CurrentPosition, 0.5f);
            if(i < points.Length - 1)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawLine(points[i] + CurrentPosition, points[i + 1] + CurrentPosition);
            }
        }
    }
}
