using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameEnding : Interactable
{
    public Image fadeoutOverlay;
    public PlayerMovement playerMovement;
    public PlayerInteractor playerInteractor;
    public DoorSounds sounds;
    public GameObject groupToDisable;
    public GameObject decision;
    public CursorLocker cursorLocker;
    public Timer timer;

    private void Start()
    {
        
    }

    private IEnumerator Fadeout()
    {
        groupToDisable.SetActive(false);
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
        sounds.PlayOutro();
        timer.enabled = false;
        yield return new WaitForSeconds(3.3f);
        decision.SetActive(true);
        cursorLocker.Unlock();
    }

    public override void AccessTask() => StartCoroutine(Fadeout());
}
