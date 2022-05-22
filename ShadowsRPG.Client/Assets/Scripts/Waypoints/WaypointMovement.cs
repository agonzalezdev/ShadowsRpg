using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementDirection
{
    Horizontal,
    Vertical
}

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] protected float speed;

    public Vector3 PositionToMove => _waypoint.GetMovementPosition(actualPointIndex);

    private Waypoint _waypoint;
    private int actualPointIndex;

    protected Vector3 lastPosition;

    protected Animator _animator;


    void Start()
    {
        actualPointIndex = 0;
        _animator = GetComponent<Animator>();
        _waypoint = GetComponent<Waypoint>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        RotateHorizontal();
        RotateVertical();
        if (CheckCurrentPoint())
        {
            UpdateWaypointIndex();
        }
    }

    private void MoveCharacter()
    {
        transform.position = Vector3.MoveTowards(transform.position, PositionToMove, speed * Time.deltaTime);
    }

    private bool CheckCurrentPoint()
    {
        float distanceToCurrentPoint = (transform.position - PositionToMove).magnitude;
        if (distanceToCurrentPoint < 0.1f)
        {
            lastPosition = transform.position;
            return true;
        }

        return false;
    }

    private void UpdateWaypointIndex()
    {
        if (actualPointIndex == _waypoint.Points.Length - 1)
        {
            actualPointIndex = 0;
        }
        else
        {
            if (actualPointIndex < _waypoint.Points.Length - 1)
            {
                actualPointIndex++;
            }
        }
    }

    protected virtual void RotateHorizontal() { }

    protected virtual void RotateVertical() { }
}
