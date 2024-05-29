using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class LocalizeText : MonoBehaviour
{
    private Text text;
    private string key;
    
    void Start()
    {
        Localize();
        LocalizationManager.OnLanguageChange += OnLanguageChange;
    }

    private void OnDestroy()
    {
        LocalizationManager.OnLanguageChange -= OnLanguageChange;
    }

    private void OnLanguageChange()
    {
        Localize();
    }

    private void Init()
    {
        text = GetComponent<Text>();
        key = text.text;
    }

    public void Localize(string newKey = null)
    {
        if(text == null)
            Init();
        
        if(newKey != null)
            key = newKey;

        text.text = LocalizationManager.GetTranslate(key);
    }
}
