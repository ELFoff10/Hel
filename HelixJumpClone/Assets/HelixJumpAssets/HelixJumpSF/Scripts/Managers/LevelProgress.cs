using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : BallEvents
{
    [SerializeField] private ScoresCollector collector;
    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    protected override void Awake()
    {
        base.Awake();

        Load();
    }
#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
#endif
    protected override void OnBallCollisionSegment(SegmentType type)
    {
        if (type == SegmentType.Finish)
        {
            currentLevel++;

            if (collector.Scores > collector.Record)
            {
                collector.Record = collector.Scores;
            }

            Save();
        }
    }
    private void Save()
    {
        PlayerPrefs.SetInt("Record", collector.Record);
        PlayerPrefs.SetInt("LevelProgress:CurrenLevel", currentLevel);
    }
    private void Load()
    {
        collector.Record = PlayerPrefs.GetInt("Record", collector.Record);
        currentLevel = PlayerPrefs.GetInt("LevelProgress:CurrenLevel", currentLevel);
    }
#if UNITY_EDITOR
    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
#endif
}
