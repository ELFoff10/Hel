using UnityEngine;

public class Mark : BallEvents
{
    [SerializeField] private Transform _transform;

    public void SetRandomRotation()
    {
        _transform.eulerAngles = new Vector3(90, Random.Range(0, 360), 0);
    }
}
