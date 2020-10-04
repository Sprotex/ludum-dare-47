using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    public Image checkboxEnabledImage;
    public Image overlayImage;
    public bool isOn = false;
    public UnityEvent<bool> OnToggle;
    public TMPro.TextMeshProUGUI TMPText;
    public Image colorImage;

    public void CustomDisable()
    {
        isOn = false;
        checkboxEnabledImage.enabled = isOn;
    }

    public void OnClick()
    {
        OnToggle.Invoke(!isOn);
        isOn = !isOn;
        checkboxEnabledImage.enabled = isOn;
    }
}
