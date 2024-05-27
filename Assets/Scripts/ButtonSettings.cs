using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSettings : MonoBehaviour
{
    [SerializeField] private Button settings;
    [SerializeField] private GameObject window;
    

    void OnEnable()
    {
        settings.onClick.AddListener(SetMenu);
    }

    void OnDisable()
    {
        settings.onClick.RemoveAllListeners();
    }

    private void SetMenu()
    {
        window.SetActive(!window.activeSelf);
    }
}
