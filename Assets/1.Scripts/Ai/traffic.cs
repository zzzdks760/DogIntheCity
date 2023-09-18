using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class traffic : MonoBehaviour
{
    //public Move move = null;
    RaycastHit hit, hit2;
    public float distance = 3.0f;
    public float distance2 = 10.0f;
    public NavMeshAgent agent;

    void Start()
    {
        agent = GameObject.Find("car_1").GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        ray();
    }

    public void ray()
    {
        Debug.DrawRay(gameObject.transform.position,gameObject.transform.forward * distance, Color.red);
        Debug.DrawRay(gameObject.transform.position,gameObject.transform.forward * distance2, Color.blue);
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit2, distance2))
        {

            if(hit2.transform.name == "trafficlight")
            {
                agent.speed = 2.0f;
                if(Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, distance))
                {
                    if(hit.transform.name == "trafficlight")
                    {
                        agent.speed = 0.0f;
                    }
                }
            }
            else
            {
                agent.speed = 8.0f;
            }
        }
    }
}
