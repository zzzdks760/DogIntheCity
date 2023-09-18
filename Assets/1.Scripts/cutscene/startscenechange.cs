using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startscenechange : MonoBehaviour
{
    private float Time = 49.0f;
    public bool change = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("changes", Time);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) || change)
        {
            LoadingSceneManager.LoadScene("SampleScene");
        }
    }

    void changes()
    {
        change = true;
    }
}
