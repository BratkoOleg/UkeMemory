using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FAQ : MonoBehaviour
{
    [SerializeField] GameObject window;
    [SerializeField] GameObject pauseBtn;
    [SerializeField] Button btn;

    void OnEnable()
    {
        btn.onClick.AddListener(ShowWindow);
    }

    void OnDisable()
    {
        btn.onClick.RemoveAllListeners();
    }

    private void ShowWindow()
    {
        if(window.activeSelf == false)
        {
            window.SetActive(true);
            pauseBtn.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            window.SetActive(false);
            pauseBtn.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
