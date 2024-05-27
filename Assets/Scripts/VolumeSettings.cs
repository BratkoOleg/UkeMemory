using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private string volumeParametr = "MasterVolume";
    [SerializeField] private Slider slider;
    private float _volumeValue;
    private const float _multiplier = 20f;

    void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
    }

    void Start()
    {
        _volumeValue = PlayerPrefs.GetFloat(volumeParametr, Mathf.Log10(slider.value) * _multiplier);
        slider.value = Mathf.Pow(10f, _volumeValue / _multiplier);  
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParametr, _volumeValue);
    }

    private void HandleSliderValueChanged(float value)
    {
        Debug.Log("changing colue");
        _volumeValue = Mathf.Log10(value) * _multiplier;
        audioMixer.SetFloat(volumeParametr, _volumeValue);
    }
}
