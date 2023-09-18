using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stressup : MonoBehaviour
{
    public stress stress = null;
    public BoxCollider doorbox;
    public bool up = false;
    public Animator dooranim;
    public GameObject wall;

    void Start()
    {
        Invoke("stressup", 26);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            up = true;
        }
        if(up == true)
        {
            stress.Stress += Time.deltaTime*5f;
        }   
        if(stress.Stress >= 100)
        {
            doorbox.enabled = true;
            dooranim.enabled = true;
            Destroy(wall);
        }
    }

    void stressup()
    {
        up = true;
    }
}
