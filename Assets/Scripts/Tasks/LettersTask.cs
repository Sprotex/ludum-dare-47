using System.Text;
using UnityEngine;

public class LettersTask : MonoBehaviour
{
    private StringBuilder stringBuilder = new StringBuilder();
    
    public TMPro.TextMeshProUGUI referenceGUI;
    public TMPro.TextMeshProUGUI inputGUI;
    public int textLength = 5;

    public const string LETTERS = "abcdefghijkmnopqrstuvwxyzABCDEFGHIJKLMNPQRSTUVWXYZ23456789.";

    public void ScrambleText()
    {
        stringBuilder.Clear();
        for (var i = 0; i < textLength; ++i)
        {
            var index = Random.Range(0, LETTERS.Length);
            stringBuilder.Append(LETTERS[index]);
        }
        referenceGUI.text = stringBuilder.ToString();
    }

    public void CheckCorrectness()
    {
        var manager = TaskManager.instance;
        var inputText = inputGUI.text;
        var referenceText = referenceGUI.text;
        if (inputText.Length < referenceText.Length)
        {
            manager.Failure();
            return;
        }
        for (var i = 0; i < referenceText.Length; ++i)
        {
            if (inputText[i] != referenceText[i])
            {
                manager.Failure();
                return;
            }
        }
        manager.Success();
    }
}
