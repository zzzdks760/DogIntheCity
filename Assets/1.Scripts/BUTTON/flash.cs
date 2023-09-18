using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flash : MonoBehaviour
{
    public maps maps;
    public GameObject flashobj;

    void Start()
    {
        maps = GameObject.Find("Map Group").GetComponent<maps>();
    }

    public void mapopen()
    {
        if(maps.mapscount == 9)
        {
            while(true)
            {
                Invoke("off", 0.5f);
                Invoke("on", 0.5f);
            }
        }

    }
    void on()
    { 
        flashobj.SetActive(true);
    }
    void off()
    {
        flashobj.SetActive(false);
    }
}
