using UnityEngine;

public class GridTextTask : GridTask
{
    private int[] gridNumbers;
    private int correctAnswer;

    public TMPro.TextMeshProUGUI title;

    private void GenerateCorrectAnswer()
    {
        gridNumbers = new int[9];
        var maxRange = 50;
        var minRange = 1;
        var a = Random.Range(minRange, maxRange);
        var b = Random.Range(minRange, maxRange);
        gridNumbers[0] = correctAnswer = a + b;
        for (var i = 1; i < gridNumbers.Length; ++i)
            do gridNumbers[i] = Random.Range(minRange, maxRange);
            while (gridNumbers[i] == correctAnswer);
        for (var i = gridNumbers.Length - 1; i >= 1; --i)
        {
            var index = Random.Range(0, i);
            var tmp = gridNumbers[i];
            gridNumbers[i] = gridNumbers[index];
            gridNumbers[index] = tmp;
        }
        for (var i = 0; i < gridNumbers.Length; ++i)
            inputToggles[i].TMPText.text = gridNumbers[i].ToString();
        title.text = string.Format("{0} + {1} = ?", a, b);
    }

    public override void Setup() => GenerateCorrectAnswer();

    protected override bool CheckCorrectnessCoordinate(int x, int y)
    {
        var index = x + y * 3;
        var isThisTileWithCorrectAnswer = gridNumbers[index] == correctAnswer;
        var isThisTileSelected = inputToggles[index].isOn;
        return isThisTileSelected != isThisTileWithCorrectAnswer;
    }
}
