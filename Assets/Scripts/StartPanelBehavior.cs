using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StartPanelBehavior : MonoBehaviour
{
    [SerializeField] private GameObject windows;
    [SerializeField] private Button btn;
    public event Action ReadyToStart;
    private int isPlayed = 0;
    public float waitTime = 5f;

    void OnEnable()
    {
        btn.onClick.AddListener(FinishReading);
    }

    void OnDisable()
    {
        btn.onClick.RemoveAllListeners();
    }

    void Start()
    {
        isPlayed = PlayerPrefs.GetInt("isPlayedInt", 0);
        PlayStart();
    }

    private void PlayStart()
    {
        if(isPlayed == 0)
        {
            // StartCoroutine(ShowArrayWindows());
            windows.SetActive(true);
        }
        else
        {
            StartRaound();
        }
    }

    private void FinishReading()
    {
        windows.SetActive(false);
        PlayerPrefs.SetInt("isPlayedInt", 1);
        StartRaound();
    }

    // private IEnumerator ShowArrayWindows()
    // {
    //     for (int i = 0; i < windows.Length; i++)
    //     {
    //         windows[i].SetActive(true);
    //         yield return new WaitForSeconds(waitTime);
    //         windows[i].SetActive(false);
    //     }
    //     PlayerPrefs.SetInt("isPlayedInt", 1);
    //     StartRaound();
    // }

    private void StartRaound()
    {
        if(ReadyToStart != null)
        {
            ReadyToStart.Invoke();
        }
        gameObject.SetActive(false);
    }
}
