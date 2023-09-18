using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class overinterface : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("interfacescene", 6.5f);
    }

    void interfacescene()
    {
        SceneManager.LoadScene("Interface");
    }


}
