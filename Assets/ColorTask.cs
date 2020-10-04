using UnityEngine;
using UnityEngine.UI;

public class ColorTask : MonoBehaviour
{
    private Color[] gridColors;
    private Color correctAnswer;
    private TaskManager manager;

    public CustomToggle[] inputToggles;
    public Image answerImage;

    private void Start() => manager = TaskManager.instance;
    private float FloatDist(float a, float b) => Mathf.Abs(a - b);
    private float ColDist(Color a, Color b) => Mathf.Max(FloatDist(a.r, b.r), FloatDist(a.g, b.g), FloatDist(a.b, b.b));

    private void GenerateCorrectAnswer()
    {
        gridColors = new Color[9];
        var r = Random.value;
        var g = Random.value;
        var b = Random.value;
        correctAnswer = new Color(r, g, b);
        answerImage.color = correctAnswer;
        for (var i = 0; i < 4; ++i)
            gridColors[i] = correctAnswer;
        for (var i = 4; i < gridColors.Length; ++i)
            do
            {
                var nr = r + (Random.value - .5f) * .2f;
                var ng = g + (Random.value - .5f) * .2f;
                var nb = b + (Random.value - .5f) * .2f;
                gridColors[i] = new Color(nr, ng, nb);
            } while (ColDist(gridColors[i], correctAnswer) < 0.05f);
        for (var i = gridColors.Length - 1; i >= 1; --i)
        {
            var index = Random.Range(0, i);
            var tmp = gridColors[i];
            gridColors[i] = gridColors[index];
            gridColors[index] = tmp;
        }
        for (var i = 0; i < gridColors.Length; ++i)
            inputToggles[i].colorImage.color = gridColors[i];
        //title.text = string.Format("{0} + {1} = ?", a, b);
    }

    public void Setup() => GenerateCorrectAnswer();

    public void CheckCorrectness()
    {
        for (var x = 0; x < 3; ++x)
            for (var y = 0; y < 3; ++y)
            {
                if (CheckCorrectnessCoordinate(x, y))
                {
                    manager.Failure();
                    return;
                }
            }
        manager.Success();
    }

    protected bool CheckCorrectnessCoordinate(int x, int y)
    {
        var index = x + y * 3;
        var isThisTileWithCorrectAnswer = gridColors[index] == correctAnswer;
        var isThisTileSelected = inputToggles[index].isOn;
        return isThisTileSelected != isThisTileWithCorrectAnswer;
    }
}
