using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;

    [SerializeField] private int scores;
    [SerializeField] private int record;
    bool isEmpty = false;

    public int Scores => scores;
    public int Record
    {
        get { return record; }
        set { record = value; }
    }
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Empty)
        {
            if (isEmpty == true)
            {
                scores += levelProgress.CurrentLevel + levelProgress.CurrentLevel + levelProgress.CurrentLevel;
            }

            isEmpty = true;
            scores += levelProgress.CurrentLevel;
        }

        if (type != SegmentType.Empty)
        {
            isEmpty = false;
        }
    }
}
