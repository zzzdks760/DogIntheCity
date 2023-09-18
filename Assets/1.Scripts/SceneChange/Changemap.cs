using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Changemap : MonoBehaviour
{
    public stress stress = null;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Simple_Door")
        {
            LoadingSceneManager.LoadScene("startscene");
        }
    }
}

