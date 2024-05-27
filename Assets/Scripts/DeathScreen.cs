using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private Button restart;
    [SerializeField] private Button exit;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private NoteRoller noteRoller;
    [SerializeField] private Text scoreText;
    private int score;

    void OnEnable()
    {
        restart.onClick.AddListener(Restart);
        exit.onClick.AddListener(Exit);
        noteRoller.RoundChanged += ChangeScore;
    }

    void OnDisable()
    {
        restart.onClick.RemoveAllListeners();
        exit.onClick.RemoveAllListeners();
        noteRoller.RoundChanged -= ChangeScore;
    }

    private void ChangeScore(int value)
    {
        score = value;
        scoreText.text = "Score: " + value;
    }   

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
