using UnityEngine;

public class BallMarkOnFloor : BallEvents
{
    [SerializeField] private Mark markPrefab;
    [SerializeField] private Transform generateTransformVisualModel;
    [SerializeField] private Transform parentTransformLevel;

    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type != SegmentType.Empty)
        {
            Mark mark = Instantiate(markPrefab);

            mark.SetRandomRotation();
            mark.transform.position = generateTransformVisualModel.position;
            mark.transform.SetParent(parentTransformLevel);
            mark.transform.position -= new Vector3(0, 0.1f, 0);
        }
    }
}
