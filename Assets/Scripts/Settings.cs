using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button back;
    [SerializeField] private GameObject window;

    private void OnEnable()
    {
        back.onClick.AddListener(Back);
    }

    private void OnDisable()
    {
        back.onClick.RemoveAllListeners();
    }

    private void Back()
    {
        window.SetActive(!window.activeSelf);
    }
}
