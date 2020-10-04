using UnityEngine;

public class DoorSounds : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string openDoorEvent;

    public void PlaySound()
    {
        var instance = FMODUnity.RuntimeManager.CreateInstance(openDoorEvent);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        instance.start();
        instance.release();
    }
}
