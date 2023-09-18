using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class skip : MonoBehaviour
{
    public PlayableDirector _introCutscene = null;
    private double _introSkipTime = 26.0f;
    public GameObject obj1, obj2, obj3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            _introCutscene.time = _introSkipTime;
            Destroy(obj1);
            Destroy(obj2);
            Destroy(obj3);
        }
    }
}
