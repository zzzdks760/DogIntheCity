using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waynocoll : MonoBehaviour
{
    public EnemyAI enemyai = null;
    public colli colli = null;
    public GameObject no1 = null, no2 = null, no3 = null, no4 = null, no5 = null, no6 = null, no7 = null, no8 = null;
    public GameObject wayno;

    public void OnTriggerStay(Collider other) {
        if(other.tag == "waypoint")
        {
            wayno = other.gameObject;
            if(enemyai.m_target == null)
            {
                if(enemyai.nearwaypoint == true)
                {
                    enemyai.nearwaypoint = false;
                    colli.waypoints = true;

                    if(wayno == no1)
                    {
                        enemyai.m_count = 0;
                    }
                    else if(wayno == no2)
                    {
                        enemyai.m_count = 1;
                    }
                    else if(wayno == no3)
                    {
                        enemyai.m_count = 2;
                    }
                    else if (wayno == no4)
                    {
                        enemyai.m_count = 3;
                    }
                    else if (wayno == no5)
                    {
                        enemyai.m_count = 4;
                    }
                    else if (wayno == no6)
                    {
                        enemyai.m_count = 5;
                    }
                    else if (wayno == no7)
                    {
                        enemyai.m_count = 6;
                    }
                    else if (wayno == no8)
                    {
                        enemyai.m_count = 7;
                    }
                }
            }
        }
    }
}
