using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    public Slider slider;
    public AudioMixer audioMixer;
    public string GroupParamName;

    private void OnEnable()
    {
        audioMixer.GetFloat(GroupParamName, out float value);
        slider.value = value;
        slider.onValueChanged.AddListener(SliderValueChanged);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(SliderValueChanged);
    }

    private void SliderValueChanged(float value)
    {
        audioMixer.SetFloat(GroupParamName, value);
    }
}
