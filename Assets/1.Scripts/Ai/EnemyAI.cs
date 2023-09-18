using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent m_enemy = null; //NavMeshAgent 변수 
    [SerializeField] Transform[] m_tfWayPoints = null; //정찰을 시키고싶은 웨이포인트 위치 배열
    public int m_count = 0;//count 변수
    public colli colli = null;
    public bool nearwaypoint = false;
    public Transform m_target = null;

    void Start()
    {
        m_enemy = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(m_target != null)
        {
            m_enemy.SetDestination(m_target.position);
            nearwaypoint = true;
        }
        else if(m_target == null && nearwaypoint == false)
        {
            MoveToNextWayPoint();
        }
    }
    
    //다음정찰지역으로 이동시켜주는 함수
    void MoveToNextWayPoint() 
    {
        if (colli.waypoints == true)//속도가 0이된다 == 추적이 끝난다.
        {
            colli.waypoints = false;
            m_enemy.SetDestination(m_tfWayPoints[m_count++].position); //순찰 목적지를 계속해서바꿔줌
            if (m_count >= m_tfWayPoints.Length) //웨이포인트가 최대치에 도달시
                m_count = 0; //처음 웨이포인트로 초기화
        }
    }

    public void SetTarget(Transform p_target)
    {
        m_target = p_target;
    }

    public void RemoveTarget()
    {
        m_target = null;
        MoveToNextWayPoint();
    }
}
