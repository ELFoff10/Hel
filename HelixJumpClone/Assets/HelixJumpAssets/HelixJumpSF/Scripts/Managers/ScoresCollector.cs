using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresCollector : BallEvents
{
    [SerializeField] private LevelProgress levelProgress;

    [SerializeField] private int scores;
    [SerializeField] private int record;

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
            scores += levelProgress.CurrentLevel;

            //if (scores > record)
            //{
            //    record = scores;  
            //}
        }
    }
}
