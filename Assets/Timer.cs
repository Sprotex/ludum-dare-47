using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textGUI;
    private float startTime;
    private void Start() => startTime = Time.time;

    private void Update()
    {
        var subTime = Time.time - startTime;
        textGUI.text = subTime.ToString("F1");
    }
}
