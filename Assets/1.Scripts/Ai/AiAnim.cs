using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAnim : MonoBehaviour
{
    public corgiround corgiround;
    public difficulty difficulty = null;
    public stress stress;
    public Questmanager Questmanager;
    public NavMeshAgent agent;
    public Animator _animator;

    void Start()
    {
        corgiround = GameObject.Find("CorgiCollder").GetComponent<corgiround>();
        Questmanager = GameObject.Find("Questmanager").GetComponent<Questmanager>();
        stress = GameObject.Find("Corgi_RM").GetComponent<stress>();
        _animator = this.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 1.8f;
    }

    void Update()
    {
        _animator.SetFloat("Blend", agent.speed * 0.1f + 0.2f, 0.1f, Time.deltaTime);
    }

    public void humango()
    {
        if(Questmanager.count == 1)
        {
            stress.Stress -= 20.0f;
            Questmanager.countquest();
        }
        
        for(int i = 0; i < corgiround.peopleList.Count; i++)
        {
            corgiround.agent[i].speed = 1.8f;
        }
    }
}
