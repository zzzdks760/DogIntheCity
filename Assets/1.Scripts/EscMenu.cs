using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscMenu : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        Debug.Log("새 게임");
    }

    public void OnClickBack()
    {
        Debug.Log("뒤로가기");
    }

    public void OnClickOption()
    {
        Debug.Log("옵션");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
