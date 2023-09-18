using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_market : MonoBehaviour
{
    private int count;
    private int count2;
    public Transform[] spawnPosArray;
    public GameObject slicedMap;

    void Start()
    {
        count = Random.Range(0, 10);//
        Instantiate(slicedMap, spawnPosArray[count]);//Instantiate(slicedMap, spawnPosArray[Random.Range(0,10));
        count2 = Random.Range(0, 10);//
        for (int i = 0; i < 100; i++)//
        {
            if (count != count2)
            {
                Instantiate(slicedMap, spawnPosArray[count2]);
                break;
            }
            else
            {
                count2 = Random.Range(0, 10);
            }
        }
    }
}
