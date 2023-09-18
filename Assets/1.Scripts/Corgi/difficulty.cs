using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class difficulty : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip trashbag;
    public PlayerMovement playerMovement = null;
    public bool surprise = false;
    public float difscore = 1;
    public double score;
    public Text scoretext;
    

    void Start()
    {

    }

    void Update()
    {
        if(difscore >= 6)
        {
            difscore = 6.0f;
        }

        if(difscore > 1)
        {
            difscore -= Time.deltaTime / 100.0f;
        }
        
        if(difscore >= 1)
        {
            score = Math.Truncate(difscore);
            scoretext.text = "x " + score;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "man")
        {
            if(playerMovement.stops == false && playerMovement.foodIndexs == -1 && Input.GetButtonDown("bark"))
            {
                surprise = true;
                difscore += 0.05f;
            }
        }
        else if(other.tag == "food")
        {
            if(Input.GetButtonDown("bite") &&  playerMovement.stops == false && playerMovement.foodIndexs == -1)
            {
                difscore += 0.02f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "trash")
        {
            difscore += 0.05f;
        }
        else if(other.tag == "trashbag" && playerMovement.run == true)
        {
            difscore += 0.05f;
            audiosource.PlayOneShot(trashbag);
        }
        else if(other.tag == "food")
        {
            difscore += 0.001f;
        }
        else if(other.tag == "trashbox")
        {
            difscore += 0.05f;
        }
        else if(other.tag == "home")
        {
            LoadingSceneManager.LoadScene("Interface");
        }
    }
}
