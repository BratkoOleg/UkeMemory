using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Image def => gameObject.GetComponent<Image>();
    public Sprite full;
    public Sprite used;
    public bool isDied;

    public void ChangeImage()
    {
        isDied = !isDied;

        if(isDied == false)
        {
            gameObject.GetComponent<Image>().sprite = full;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = used;
        }
    }

    public void SetDefault()
    {
        isDied = false;
        gameObject.GetComponent<Image>().sprite = full;
    }
}
