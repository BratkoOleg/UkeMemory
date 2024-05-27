using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    public Text    BestscoreTest;
    private int BestScore;
    [SerializeField] private NoteRoller noteRoller;

    void OnEnable()
    {
        noteRoller.RoundChanged += ChangeScore;
    }

    void OnDisable()
    {
        noteRoller.RoundChanged -= ChangeScore;
    }

    void Start()
    {
        BestScore = LoadGame();
        BestscoreTest.text = "Best: " + BestScore;
        score = gameObject.GetComponent<Text>();
    }

    private void ChangeScore(int Score)
    {
        score.text = "Score: " + Score;
        if(BestScore < Score)
        {
            SaveGame(Score);
            BestscoreTest.text = "Best: " + Score;
        }
    }

    private void SaveGame(int Score)
    {
        PlayerPrefs.SetInt("SavedInteger", Score);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    private int LoadGame()
    {
        int bestScore = 0;
        if (PlayerPrefs.HasKey("SavedInteger"))
        {
            bestScore = PlayerPrefs.GetInt("SavedInteger");
        }
        else
        {
            return bestScore;
        }
        return bestScore;
    }
}
