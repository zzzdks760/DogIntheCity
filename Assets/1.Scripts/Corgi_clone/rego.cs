using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class rego : MonoBehaviour
{
    public NavMeshAgent agent;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    void regos()
    {
        agent.speed = 3.5f;
    }
}
