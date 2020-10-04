using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameEnding : Interactable
{
    public Image fadeoutOverlay;
    public PlayerMovement playerMovement;
    public PlayerInteractor playerInteractor;
    public DoorSounds sounds;

    private IEnumerator Fadeout()
    {
        sounds.PlaySound();
        playerMovement.enabled = false;
        playerInteractor.enabled = false;
        var interpolationCount = 30;
        var waitTime = 1f;
        var waitInstruction = new WaitForSeconds(waitTime / interpolationCount);
        var color = Color.black;
        color.a = 0;
        for (var i = 0; i < interpolationCount; ++i)
        {
            yield return waitInstruction;
            color.a = i / (float) (interpolationCount - 1);
            fadeoutOverlay.color = color;
        }
    }

    public override void AccessTask()
    {
        StartCoroutine(Fadeout());
    }
}
