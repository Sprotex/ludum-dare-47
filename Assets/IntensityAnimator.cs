using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityAnimator : MonoBehaviour
{
    public Light animatedLight;
    private float maxIntensity;
    private float offset = .2f;

    private void Start() => maxIntensity = animatedLight.intensity;
    private void Update() => animatedLight.intensity = maxIntensity - offset + offset * Mathf.PerlinNoise(0f, Time.time * 5f);
}
