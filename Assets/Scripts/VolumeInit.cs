using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeInit : MonoBehaviour
{
    [SerializeField] private string volumeParametr = "MasterVolume";
    [SerializeField] private AudioMixer audioMixer;
    void Start()
    {
        var volumeValue = PlayerPrefs.GetFloat(volumeParametr, -10f);
        audioMixer.SetFloat(volumeParametr, volumeValue);
    }
}
