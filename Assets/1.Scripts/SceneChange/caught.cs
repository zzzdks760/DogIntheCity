using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class caught : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            Debug.Log("1");
            LoadingSceneManager.LoadScene("Interface");
        }

    }
}
