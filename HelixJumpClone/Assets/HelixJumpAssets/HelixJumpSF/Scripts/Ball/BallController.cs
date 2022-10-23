using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneColliderTrigger
{
    private BallMovement movement;

    [HideInInspector] public UnityEvent<SegmentType> CollisionSegment;

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

            CollisionSegment.Invoke(floorSegment.Type);
        }
    }
}
