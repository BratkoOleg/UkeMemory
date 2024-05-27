using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField] Button play => GetComponent<Button>();

    void OnEnable()
    {
        play.onClick.AddListener(Play);
    }

    void OnDisable()
    {
        play.onClick.RemoveAllListeners();
    }

    private void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
