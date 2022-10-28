using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LevelPalette
{
    public Color AxisColor;
    public Color BallColor;
    public Color DefaultSegmentColor;
    public Color TrapSegmentColor;
    public Color FinishSegmentColor;
    public Color BackgroundColor;
    public Color HighlightColor;

}

public class LevelColors : MonoBehaviour
{
    [SerializeField] private LevelPalette[] palette;

    [SerializeField] private Material axisMaterial;
    [SerializeField] private Material ballMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material trapMaterial;
    [SerializeField] private Material finishMaterial;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private new Camera camera;
    void Start()
    {
        int index = Random.Range(0, palette.Length);

        axisMaterial.color = palette[index].AxisColor;
        ballMaterial.color = palette[index].BallColor;
        defaultMaterial.color = palette[index].DefaultSegmentColor;
        trapMaterial.color = palette[index].TrapSegmentColor;
        finishMaterial.color = palette[index].FinishSegmentColor;
        backgroundImage.color = palette[index].BackgroundColor;
        camera.backgroundColor= palette[index].HighlightColor;

    }
}
