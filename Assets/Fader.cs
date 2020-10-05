using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image image;

    private IEnumerator FadeOutInner()
    {
        var interpolationSteps = 20;
        var time = 1f;
        var waitInstruction = new WaitForSeconds(time / interpolationSteps);
        var color = image.color;
        for (var i =0; i < interpolationSteps; ++i)
        {
            var t = i / (float)(interpolationSteps - 1);
            color.a = 1 - t;
            image.color = color;
            yield return waitInstruction;
        }
    }

    public void FadeOut() => StartCoroutine(FadeOutInner());
}
