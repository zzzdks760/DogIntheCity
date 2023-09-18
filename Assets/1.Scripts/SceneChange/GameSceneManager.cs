using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public HungerController hungerController;

    void Start()
    {
        hungerController = GameObject.Find("Corgi_RM").GetComponent<HungerController>();
    }


    void Update()
    {
        gameover();
    }

    void gameover()
    {
        if(hungerController.Hunger == 0)
        {
            LoadingSceneManager.LoadScene("gmaeover");
        } 
    }
}
