using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEOVERSCENE : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("gmaeover", LoadSceneMode.Additive);
    }
}
