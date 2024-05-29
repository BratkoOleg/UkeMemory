using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLanguageText : MonoBehaviour
{
    [SerializeField]
    private LocalizeText text;
    [SerializeField]
    public string key;

    private void Start()
    {
        ChangeLine();
    }

    public void ChangeLine()
    {
            text.Localize(key);
    }
}
