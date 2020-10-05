using System;
using UnityEngine;

public class DoorSounds : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string openDoorEvent;
    [FMODUnity.EventRef]
    public string outroEvent;

    public void PlaySound()
    {
        var instance = FMODUnity.RuntimeManager.CreateInstance(openDoorEvent);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        instance.start();
        instance.release();
    }

    public void PlayOutro()
    {
        var instance = FMODUnity.RuntimeManager.CreateInstance(outroEvent);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        instance.start();
        instance.release();
    }
}
