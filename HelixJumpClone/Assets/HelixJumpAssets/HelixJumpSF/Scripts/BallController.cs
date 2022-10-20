using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneColliderTrigger
{
    private BallMovement movement;

    private void Start()
    {
        movement = GetComponent<BallMovement>();
    }
    protected override void OnOneTriggerEnter(Collider other)
    {

        FloorSegment floorSegment = other.GetComponent<FloorSegment>();  

        if (floorSegment != null)
        {
            if (floorSegment.Type == SegmentType.Empty)
            {
                movement.Fall(other.transform.position.y);
            }

            if (floorSegment.Type == SegmentType.Default)
            {
                movement.Jump();
            }

            if (floorSegment.Type == SegmentType.Trap || floorSegment.Type == SegmentType.Finish)
            {
                movement.Stop();
            }
        }
    }
}
