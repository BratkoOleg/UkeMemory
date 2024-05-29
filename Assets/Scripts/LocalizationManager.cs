using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Xml;

public class LocalizationManager : MonoBehaviour
{
    public static int SelectedLanguage { get; private set;}

    public static event LanguageChangeHandler OnLanguageChange;
    public delegate void LanguageChangeHandler();

    private static Dictionary<string, List<string>> localization;

    [SerializeField]
    private TextAsset textFile;

    private void Awake()
    {
        if(localization == null)
            LoadLocalization();

        if(PlayerPrefs.HasKey("lngID") != false)
        {
            SetLanguage(PlayerPrefs.GetInt("lngID"));
        }
    }

    public void SetLanguage(int id)
    {
        SelectedLanguage = id;
        OnLanguageChange?.Invoke();
        PlayerPrefs.SetInt("lngID", id);
        Debug.Log("saved langua: " + id);
    }

    private void LoadLocalization()
    {
        localization = new Dictionary<string, List<string>>();

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(textFile.text);

        foreach (XmlNode key in xmlDocument["Keys"].ChildNodes)
        {
            string keyStr = key.Attributes["Name"].Value;

            var values = new List<string>();
            foreach (XmlNode tranlate in key["Translates"].ChildNodes)
            {
                values.Add(tranlate.InnerText);
            }
            localization[keyStr] = values;
        }
    }

    public static string GetTranslate( string key, int languageId = -1)
    {
        if(languageId == -1)
            languageId = SelectedLanguage;
        
        if(localization.ContainsKey(key))
            return localization[key][languageId];
        return key;
    }
}
