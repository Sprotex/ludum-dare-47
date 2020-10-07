using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineSensitivitySettings : MonoBehaviour
{
    public CinemachineVirtualCamera cmCamera;
    
    private void OnEnable()
    {
        var sensitivity = PlayerPrefs.GetFloat(Settings.actualSensitivityKey, 1f);
        var maxSpeed = sensitivity * 300;
        var pov = cmCamera.GetCinemachineComponent<CinemachinePOV>();
        pov.m_HorizontalAxis.m_MaxSpeed = maxSpeed;
        pov.m_VerticalAxis.m_MaxSpeed = maxSpeed;
    }
}
