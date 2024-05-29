using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Random=UnityEngine.Random;

public class NoteRoller : MonoBehaviour
{
    public event Action<int> RoundChanged;
    public event Action<float> RoundEnded;
    public event Action<bool> RoundStarted; 
    public event Action GotDamage; 
    //public event Action Failed; 
    [SerializeField] private int Notenumber = 1;
    private int Rounds = 0;
    [SerializeField] private List<int> Notes;
    [SerializeField] private GameObject[] Strings = new GameObject[4];
    private Dictionary<int, GameObject> StringsDict = new Dictionary<int, GameObject>();
    [SerializeField] private float timeBtwnNotes = 2f;
    [SerializeField] private bool RoundIsReady = false;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] float[] percentrages;
    [SerializeField] GameObject[] Objects;
    private float TimerBitweenRounds = 1f;
    public StartPanelBehavior startPanelBehavior;

    private void OnEnable()
    {
        startPanelBehavior.ReadyToStart += AddNote;
    }

    private void OnDisable()
    {
        startPanelBehavior.ReadyToStart -= AddNote;
    }

    void Start()
    {

        StringsDict.Add(1,Strings[0]);
        StringsDict.Add(2,Strings[1]);
        StringsDict.Add(3,Strings[2]);
        StringsDict.Add(4,Strings[3]);


        // AddNote();
    }
    private void AddNote()
    {
        Notes.Add(Convert.ToInt32(Objects[GetNumber()].name));
        ShowArray();
    }
    public int GetNumber()
    {
        float random = Random.Range(0f,1f);
        float numForAdding = 0;
        float total = 0;
        for (int i = 0; i < percentrages.Length; i++)
        {
            total += percentrages[i];
        }
        for (int i = 0; i < Objects.Length; i++)
        {
            if(percentrages[i] / total + numForAdding >= random)
            {
                return i;
            }
            else
            {
                numForAdding += percentrages[i] / total;
            }
        }
        return 0;
    }

    public void ChechNote(int CheckableNote)
    {
        if(RoundIsReady)
        {
            if(Notes.Count >= Notenumber)
            {
                int index = Notenumber - 1;
                int neededNote = Notes[index];

                if(CheckableNote == neededNote)
                {
                    Debug.Log("u right");
                    Notenumber++;
                }
                else
                {
                    if(GotDamage != null)
                    {
                        GotDamage.Invoke();
                    }
                    Strings[CheckableNote -1].GetComponent<String>().StartFail();
                    Strings[neededNote - 1].GetComponent<String>().ShowItself(false);
                    EndRoundWithFail();
                }
            }
            if(Notes.Count < Notenumber)
            {
                Notenumber = 1; 
                EndRound();
            }
        }
    }
    private void EndRoundWithFail()
    {
        Notenumber = 1; 
        if(healthBar.Health > 0)
            ShowArray();
        else
        {
            if(RoundChanged != null)
                RoundChanged.Invoke(Rounds);
        }
    }
    private void EndRound()
    {
        Rounds++;
        if(RoundChanged != null)
        {
            RoundChanged.Invoke(Rounds);
        }
        
        StartCoroutine(TimerForNextRound());
    }

    private IEnumerator TimerForNextRound()
    {
        if(RoundEnded != null)
        {
            RoundEnded.Invoke(TimerBitweenRounds);
        }

        yield return new WaitForSeconds(TimerBitweenRounds);

        if(TimerBitweenRounds < 3f)
            TimerBitweenRounds += 0.5f;
            
        AddNote();
        IncreaseDifficult();
    }

    private void IncreaseDifficult()
    {
        if(timeBtwnNotes >= 0.5f)
            timeBtwnNotes -= 0.2f;
    }
    private void ShowArray()
    {
        string array = "";
        foreach (var note in Notes)
        {
            array += " " + note.ToString();
        }
        Debug.Log(array);

        StartCoroutine(ChangeNote());
    }
    private IEnumerator ChangeNote()
    {
        RoundIsReady = false;
        if(RoundChanged != null)
        {
            RoundStarted.Invoke(RoundIsReady);
        }
        yield return new WaitForSeconds(1f);
        foreach (var note in Notes.ToArray())
        {
            StringsDict[note].gameObject.GetComponent<String>().ShowItself(true);
            yield return new WaitForSeconds(timeBtwnNotes);
        }
        RoundIsReady = true;
        if(RoundChanged != null)
        {
            RoundStarted.Invoke(RoundIsReady);
        }
    }
    public void Restart()
    {
        
        Notenumber = 1;
        Rounds = 1;
        RoundIsReady = false;
        Notes.Clear();
        Start();
    }
}
