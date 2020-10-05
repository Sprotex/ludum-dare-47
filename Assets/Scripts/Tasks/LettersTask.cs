using System.Text;
using UnityEngine;

public class LettersTask : MonoBehaviour
{   
    public TMPro.TextMeshProUGUI referenceGUI;
    public TMPro.TextMeshProUGUI inputGUI;
    public string[] inputs;

    private int index = -1;

    public void ScrambleText()
    {
        ++index;
        if (index >= inputs.Length)
            index = 0;
        referenceGUI.text = inputs[index];
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
