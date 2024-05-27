using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button restart;
    [SerializeField] private Button exit;
    [SerializeField] private Button pause;
    [SerializeField] private GameObject window;

    void OnEnable()
    {
        restart.onClick.AddListener(Restart);
        exit.onClick.AddListener(Exit);
        pause.onClick.AddListener(SetWindow);
    }

    void OnDisable()
    {
        restart.onClick.RemoveAllListeners();
        exit.onClick.RemoveAllListeners();
        pause.onClick.RemoveAllListeners();
        Time.timeScale = 1;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Exit()
    {
        SceneManager.LoadScene(0);
    }

    private void SetWindow()
    {
        if(Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;

        window.SetActive(!window.activeSelf);
    }
}
