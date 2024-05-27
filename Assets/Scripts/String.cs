using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class String : SoundManager
{
    [SerializeField] private Button btn;
    [SerializeField] private NoteRoller noteRoller;
    [SerializeField] private int noteNumber;
    [SerializeField] private float sec = 1f;
    public AudioClip sound;
    private bool canBePlayed = false;
    private Image image;
    
    void OnEnable()
    {
        btn = gameObject.GetComponent<Button>();
        image = gameObject.GetComponent<Image>();
        btn.onClick.AddListener(CheckNote);
        noteRoller.RoundStarted += ChangeFlag;
        noteRoller.Failed += StartFail;
    }
    void OnDisable()
    {
        btn.onClick.RemoveAllListeners();
        noteRoller.RoundStarted -= ChangeFlag;
        noteRoller.Failed -= StartFail; 
    }

    public void StartFail()
    {
        StartCoroutine(FailedRound());
    }

    public void CheckNote()
    {
        if(canBePlayed)
        {
            StartCoroutine(Pressed());
            PlaySound(sound, 1);
            noteRoller.GetComponent<NoteRoller>().ChechNote(noteNumber);
        }
    }

    public void ShowItself(bool needSound)
    {
        if(needSound)
            PlaySound(sound, 1);
        StartCoroutine(ChangeSkin());
    }

    private void ChangeFlag(bool flag)
    {
        canBePlayed = flag;
        if(canBePlayed)
            btn.interactable = true;
        else
            btn.interactable = false;
    }

    private IEnumerator ChangeSkin()
    {
        image.color = new Color(0,255,0);
        yield return new WaitForSeconds(sec);
        image.color = new Color(255,255,255);
    }

    private IEnumerator Pressed()
    {
        image.color = new Color(0,255,0);
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(255,255,255);
    }

    private IEnumerator FailedRound()
    {
        image.color = new Color(255,0,0);
        yield return new WaitForSeconds(0.1f);
        image.color = new Color(255,255,255);
    }
}
