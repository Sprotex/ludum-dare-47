using UnityEngine;

[System.Serializable]
public class ImageBoolPair
{
    public Sprite sprite;
    public bool isCorrect;
}

public class GridTask : MonoBehaviour
{
    protected bool[,] correctAnswers = new bool[3, 3];
    protected TaskManager manager;
    public CustomToggle[] inputToggles;
    public ImageBoolPair[] fillData;

    private void Start() => manager = TaskManager.instance;

    protected void ShuffleFillData()
    {
        for (var i = fillData.Length - 1; i >= 2; --i)
        {
            var index = Random.Range(0, i - 1);
            var tmp = fillData[index];
            fillData[index] = fillData[i];
            fillData[i] = tmp;
        }
    }

    public virtual void Setup()
    {
        ShuffleFillData();
        for (var x = 0; x < 3; ++x)
            for (var y = 0; y < 3; ++y)
            {
                var fillDataIndex = x + y * 3;
                correctAnswers[x, y] = fillData[fillDataIndex].isCorrect;
                inputToggles[fillDataIndex].overlayImage.sprite = fillData[fillDataIndex].sprite;
            }
    }

    public void CheckCorrectness()
    {
        for (var x = 0; x < 3; ++x)
            for (var y = 0; y < 3; ++y)
            {
                var index = x + y * 3;
                if (correctAnswers[x, y] != inputToggles[index].isOn)
                {
                    manager.Failure();
                    return;
                }
            }
        manager.Success();
    }
}
