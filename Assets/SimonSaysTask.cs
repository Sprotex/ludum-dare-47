using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SimonSaysTask : MonoBehaviour
{
    private int[] order;
    private int index;
    private TaskManager manager;
    public Image[] highlighters;
    public float timeBetweenHighlighting = 5f;

    public void Setup()
    {
        order = new int[4];
        index = 0;
        manager = TaskManager.instance;
        for (var i = 0; i < order.Length; ++i)
            order[i] = Random.Range(0, 4);
        StartCoroutine(HighlightingCoroutineCoroutine());
    }

    private IEnumerator HighlightingCoroutineCoroutine()
    {
        var waitInstruction = new WaitForSeconds(timeBetweenHighlighting);
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            StartCoroutine(HighlightingCoroutine());
            yield return waitInstruction;
        }
    }

    private IEnumerator HighlightingCoroutine()
    {
        var waitInstruction = new WaitForSeconds(.4f);
        for (var i = 0; i < order.Length; ++i)
        {
            var highlighterIndex = order[i];
            var highlighter = highlighters[highlighterIndex];
            highlighter.enabled = true;
            yield return waitInstruction;
            highlighter.enabled = false;
            yield return waitInstruction;
        }
    }

    public void Teardown() => StopAllCoroutines();

    public void ButtonMessage(int number)
    {
        if (order[index] != number)
        {
            manager.Failure();
            return;
        }
        ++index;
        if (index >= order.Length)
            manager.Success();
    }
}
