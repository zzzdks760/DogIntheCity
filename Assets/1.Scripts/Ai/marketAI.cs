using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class marketAI : MonoBehaviour
{
    public Animator _animator;
    public int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void numchange()
    {
        num = UnityEngine.Random.Range(0, 5);
        if(num == 1)
        {
            _animator.SetTrigger("anim1");
        }
        else if(num == 2)
        {
            _animator.SetTrigger("anim2");
        }
        else if(num == 3)
        {
            _animator.SetTrigger("anim3");
        }
        else if(num == 4)
        {
            _animator.SetTrigger("anim4");
        }
        else
        {
            _animator.SetTrigger("anim5");
        }
    }
}
