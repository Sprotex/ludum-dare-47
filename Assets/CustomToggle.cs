﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CustomToggle : MonoBehaviour
{
    public Image checkboxEnabledImage;
    public Image overlayImage;
    public bool isOn = false;
    public UnityEvent<bool> OnToggle;
    public TMPro.TextMeshProUGUI TMPText;

    public void CustomDisable() => isOn = false;

    public void OnClick()
    {
        OnToggle.Invoke(!isOn);
        isOn = !isOn;
        checkboxEnabledImage.enabled = isOn;
    }
}
