using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoponoff : MonoBehaviour
{
    public PlayerMovement pm = null;
    public GameObject on, off;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pm.stops == false)
        {
            off.SetActive(true);
            on.SetActive(false);
        }
        else if(pm.stops == true)
        {
            off.SetActive(false);
            on.SetActive(true);
        }
    }

    public void stoponoffs()
    {
        if(pm.stops == false)
        {
            pm.stops = true;
        }
        else if(pm.stops == true)
        {
            pm.stops = false;
        }
    }
}
