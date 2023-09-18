using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaualPause : MonoBehaviour
{
    public CameraMovement CameraMovement;

    void Start()
    {
        CameraMovement = GameObject.Find("Cameras").GetComponent<CameraMovement>();
    }

    public void Maualpause()
    {
        Time.timeScale = 0f;
        CameraMovement.enabled = false;
    }
}
