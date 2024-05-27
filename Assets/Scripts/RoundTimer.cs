using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour
{
    [SerializeField] private Image slider;
    [SerializeField] private GameObject _window;
    [SerializeField] private NoteRoller noteRoller;
    private float Deftime;
    private float maxTime;
    private bool isStart = false;

    private void Start()
    {
        noteRoller.RoundEnded += ShowProgressBar;
    }

    private void OnDisable()
    {
        noteRoller.RoundEnded -= ShowProgressBar;
    }

    void Update()
    {
        if(isStart && Deftime >= 0)
        {
            Deftime -= Time.deltaTime;
            slider.fillAmount = Deftime / maxTime;
        }
        else
        {
            _window.SetActive(false);
            isStart = false;
        }
    }

    public void ShowProgressBar(float time)
    {
        _window.SetActive(true);
        maxTime = time;
        Deftime = maxTime;
        isStart = true;
    }
}
