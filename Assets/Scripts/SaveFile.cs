using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFile
{
    public static void SaveGame(int Score)
    {
        PlayerPrefs.SetInt("SavedInteger", Score);
        PlayerPrefs.Save();
        Debug.Log("Game data saved!");
    }

    public static int LoadGame()
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
