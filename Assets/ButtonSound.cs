using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string soundEvent;
    public int isSubmitButton;

    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        var instance = FMODUnity.RuntimeManager.CreateInstance(soundEvent);
        instance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform));
        instance.setParameterByName("submit", isSubmitButton);
        instance.start();
        instance.release();
    }
}
