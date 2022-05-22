using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : WaypointMovement
{
    [SerializeField] private MovementDirection movementDirection;

    private readonly int walkDown = Animator.StringToHash("WalkDown");

    protected override void RotateHorizontal()
    {
        if (movementDirection != MovementDirection.Horizontal)
        {
            return;
        }

        if (PositionToMove.x > lastPosition.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    protected override void RotateVertical()
    {
        if (movementDirection != MovementDirection.Vertical) 
            return;

        if(PositionToMove.y > lastPosition.y)
        {
            _animator.SetBool(walkDown, false);
        }
        else
        {
            _animator.SetBool(walkDown, true);
        }
    }
}
