using UnityEngine;

public class VolumeSetter : MonoBehaviour
{
    private void OnEnable()
    {
        var bus = FMODUnity.RuntimeManager.GetBus("bus:/");
        var volume = PlayerPrefs.GetFloat(Settings.volumeKey, 0.5f);
        bus.setVolume(volume);
    }
}
