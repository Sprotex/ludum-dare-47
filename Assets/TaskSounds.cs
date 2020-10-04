using UnityEngine;

public class TaskSounds : MonoBehaviour
{
    public Transform soundPosition;
    [FMODUnity.EventRef]
    public string successEvent;
    [FMODUnity.EventRef]
    public string failureEvent;

    private int currentCombo;

    private void Start() => currentCombo = 0;
    private void PlaySound(string eventString)
    {
        var instance = FMODUnity.RuntimeManager.CreateInstance(eventString);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(soundPosition));
        instance.setParameterByName("Combo", currentCombo);
        instance.start();
        instance.release();
    }

    public void GoHome()
    {
        currentCombo = 13;
        PlaySound(successEvent);
    }

    public void Success()
    {
        ++currentCombo;
        if (currentCombo > 12)
            currentCombo = 12;
        PlaySound(successEvent);
    }
    public void Failure()
    {
        currentCombo = 0;
        PlaySound(failureEvent);
    }
}
