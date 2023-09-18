using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] maps;
    public int cnt;
    public GameObject[] clone;
    public Animator _animator;
    public bool clone1 = false, clone2 = false, clone3 = false, clone4 = false;

    void Start()
    {
        cnt = UnityEngine.Random.Range(0, 4);
        _animator = clone[cnt].GetComponent<Animator>();
        maps[cnt].SetActive(true);
        _animator.SetLayerWeight(1, 1f);
        _animator.SetTrigger("New Trigger");
        if(cnt == 0)
        {
            clone1 = true;
        }
        else if(cnt == 1)
        {
            clone2 = true;
        }
        else if(cnt == 2)
        {
            clone3 = true;
        }
        else if(cnt == 3)
        {
            clone4 = true;
        }
    }

    void Update()
    {
        
    }
}
