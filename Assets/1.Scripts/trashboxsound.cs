using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashboxsound : MonoBehaviour
{
    public AudioSource audiosource;
    public AudioClip cap;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "land")
        {
            audiosource.PlayOneShot(cap);
        }
    }
}
