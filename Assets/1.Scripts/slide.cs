using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slide : MonoBehaviour
{
    public Text num = null;
    public float a;

    void Start()
    {
        num.text = (a/500).ToString();
        a = 40.0f;
    }

    // Update is called once per frame
    public void valueupdate(float value)
    {
        a = Mathf.RoundToInt(value * 100);
        num.text = (a/500).ToString();
    }
}
