using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu, Maualmenu;
    public CameraMovement CameraMovement;

    void Start()
    {
        CameraMovement = GameObject.Find("Cameras").GetComponent<CameraMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        CameraMovement.enabled = false;
    }

    public void Maualpause()
    {
        Time.timeScale = 0f;
        CameraMovement.enabled = false;
    }

    public void mp()
    {
        Maualmenu.SetActive(true);
    }

    public void Maualstart()
    {
        Maualmenu.SetActive(false);
        Time.timeScale = 1f;
        CameraMovement.enabled = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        CameraMovement.enabled = true;
    }

    public void Home(int sceneID)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneID);
    }
}

