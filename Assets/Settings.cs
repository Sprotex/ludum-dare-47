using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public const string sensitivityKey = "sensitivity";
    public const string actualSensitivityKey = "actual sensitivity";
    public const string volumeKey = "volume";
    private float volume;
    private float sensitivity;

    public Slider volumeSlider;
    public Slider sensitivitySlider;

    public void UpdateSettings()
    {
        PlayerPrefs.SetFloat(volumeKey, volumeSlider.value);
        PlayerPrefs.SetFloat(sensitivityKey, sensitivitySlider.value);
        var actualSensitivity = 1f;
        if (sensitivitySlider.value >= 4f)
        {
            var t = Mathf.InverseLerp(4f, 8f, sensitivitySlider.value);
            actualSensitivity = Mathf.Lerp(1f, 4f, t);
        }
        if (sensitivitySlider.value < 4f)
        {
            var t = Mathf.InverseLerp(0f, 4f, sensitivitySlider.value);
            actualSensitivity = Mathf.Lerp(1 / 8f, 1f, t);
        }
        PlayerPrefs.SetFloat(actualSensitivityKey, actualSensitivity);
    }

    void Start()
    {
        volume = PlayerPrefs.GetFloat(volumeKey, 0.5f);
        sensitivity = PlayerPrefs.GetFloat(sensitivityKey, 4f);
        if (volumeSlider != null)
            volumeSlider.value = volume;
        if (sensitivitySlider != null)
            sensitivitySlider.value = sensitivity;
    }
}
