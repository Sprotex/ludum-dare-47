using UnityEngine;
using UnityEngine.UI;

public class IngameSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public Slider sensitivitySlider;

    public CinemachineSensitivitySettings sensitivitySettings;
    public VolumeSetter volumeSetter;

    private void Start()
    {
        volumeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(Settings.volumeKey, 0.5f));
        sensitivitySlider.SetValueWithoutNotify(PlayerPrefs.GetFloat(Settings.sensitivityKey, 1f));
    }

    private void ToggleMB(MonoBehaviour mb)
    {
        mb.enabled = false;
        mb.enabled = true;
    }

    public void UpdateSettings()
    {
        Settings.UpdateValues(volumeSlider.value, sensitivitySlider.value);
        ToggleMB(volumeSetter);
        ToggleMB(sensitivitySettings);
    }
}
