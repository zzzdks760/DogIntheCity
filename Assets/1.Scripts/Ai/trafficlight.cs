using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficlight : MonoBehaviour
{
    public float delayTime = 5;
    public bool redlight = true;
    public bool isDelay = false;
    public BoxCollider box;
    public GameObject[] greenlights, redlights;

    void Update()
    {
        if(!isDelay)
        {
            isDelay = true;    
            StartCoroutine(trafficcolor());
        }
    }

    IEnumerator trafficcolor()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        isDelay = false;
        if(redlight == true)
        {
            redlight = false;
            box.enabled = false;
            for(int i = 0; i <= 1; i++)
            {
                greenlights[i].SetActive(true);
                redlights[i].SetActive(false);
            }
            
        }
        else
        {
            redlight = true;
            box.enabled = true;
            for(int i = 0; i <= 1; i++)
            {
                greenlights[i].SetActive(false);
                redlights[i].SetActive(true);
            }
        }
    }
}
