﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class homecutscene : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("homecut", LoadSceneMode.Additive);
    }
}
