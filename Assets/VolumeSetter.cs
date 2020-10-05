using UnityEngine;

public class VolumeSetter : MonoBehaviour
{
    private void Start()
    {
        var bus = FMODUnity.RuntimeManager.GetBus("bus:/");
        var volume = PlayerPrefs.GetFloat(Settings.volumeKey, 0.5f);
        bus.setVolume(volume);
    }
}
