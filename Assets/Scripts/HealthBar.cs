using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    public int _hp;
    private int _maxHp;
    public List<GameObject> hearts;
    [SerializeField] private GameObject DeathScreen;
    private Transform tra => gameObject.GetComponent<Transform>();
    public NoteRoller noteRoller;
    public Action HealthChanged;

    public int Health
    {
        get => _hp;
        set
        {
            if(value >= 0 && value <= _maxHp)
            {
                _hp = value;

                if(HealthChanged != null)
                {
                    HealthChanged.Invoke();
                }
            }
        }
    }

    void OnEnable()
    {
        noteRoller.GotDamage += GotDamage;
    }

    void OnDisable()
    {
        noteRoller.GotDamage -= GotDamage;
    }

    void Start()
    {
        for (int i = 0; i < tra.childCount; i++)
        {
            hearts.Add(tra.GetChild(i).transform.gameObject);
        }

        foreach (var item in hearts)
        {
            item.GetComponent<Heart>().SetDefault();
        }

        _maxHp = hearts.Count;
        _hp = _maxHp;
    }

    private void GotDamage()
    {
        
        Health -= 1;
        SetHealthBar();
    }

    private void SetHealthBar()
    {   
        for (int i = 1; i < hearts.Count; i++)
        {
            Heart heart = hearts[hearts.Count - i].gameObject.GetComponent<Heart>();
            if(heart.isDied == false)
            {    
                heart.ChangeImage();
                break;
            }
            if(Health == 0)
            {
                DeathScreen.SetActive(true);
                // StartCoroutine(ShowFail());
            }
        }
    }

    private IEnumerator ShowFail()
    {
        yield return new WaitForSeconds(1f);
        DeathScreen.SetActive(true);
        //SceneManager.LoadScene(0);
    }

    public void Restore()
    {
        foreach (var item in hearts)
        {
            item.GetComponent<Heart>().SetDefault();
        }

        _maxHp = hearts.Count;
        _hp = _maxHp;
    }
}
