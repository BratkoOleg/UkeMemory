using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomNote : MonoBehaviour
{
    [SerializeField] float[] percentrages;
    [SerializeField] GameObject[] Objects;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Objects[GetNumber()].name);
        }
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
}
