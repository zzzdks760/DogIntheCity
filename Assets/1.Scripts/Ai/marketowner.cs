using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class marketowner : MonoBehaviour
{
    public Animator _animator;
    public GameObject lookfronts;
    public HealthController hp;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        hp = GameObject.Find("CorgiCollder").GetComponent<HealthController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _animator.SetTrigger("attack");
            transform.LookAt(other.transform.position);
            if(Random.Range(0, 25) == 0)
            {
                hp.PlayerHealth -= 1;
            }
        }
    }

    void lookfront()
    {
        transform.LookAt(lookfronts.transform.position);
    }
}
