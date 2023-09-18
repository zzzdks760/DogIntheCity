using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] float m_angle = 0f;//시야의 각도
    [SerializeField] float m_distance = 0f;//시야 한계거리
    [SerializeField] LayerMask m_layerMask = 0;//타겟의 레이어검출
    [SerializeField] EnemyAI m_enemy = null;
    public colli colli = null;

    //시야를 체크해주는 함수
    void Sight()
    {
        //일정 반경내에있는 플레이어의 collider검출
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_distance, m_layerMask);
        //검출되었다면
        if (t_cols.Length > 0)
        {
            //player의 transform정보를 받아온다.
            Transform t_tfPlayer = t_cols[0].transform;
            //player의 방향을 구해준다.
            Vector3 t_direction = (t_tfPlayer.position - transform.position).normalized;
            //monster의 z축 방향과 player의 방향간의 각도차이를 구함
            float t_angle = Vector3.Angle(t_direction, transform.forward);
            
            if(t_angle < m_angle * 0.5f)
            {
                
                RaycastHit hit;
                if (Physics.Raycast(transform.position + transform.forward, t_direction, out hit, m_distance))
                {
                    if (hit.transform.tag == "Player")
                    {
                        Debug.DrawRay(transform.position + transform.up, t_direction, Color.red);
                        m_enemy.SetTarget(t_tfPlayer);////////
                        transform.LookAt(t_tfPlayer);//player 바라보기
                        transform.position = Vector3.Lerp(transform.position, t_tfPlayer.position, 0.005f);
                        colli.waypoints = true;
                    }
                }
                
                /*
                if(Physics.Raycast(transform.position, transform.forward, out RaycastHit t_hit, m_distance)) //2값: t_direction
                {   //플레이어의 이름을 Player로 맞춰줘야함.
                    if (t_hit.transform.name == "Corgi_RM")
                    {
                        //Debug.DrawRay(transform.position, transform.forward, Color.red); //t_direction * m_distance
                        m_enemy.SetTarget(t_tfPlayer);////////
                        transform.LookAt(t_tfPlayer);//player 바라보기
                        transform.position = Vector3.Lerp(transform.position, t_hit.transform.position, 0.005f);
                        colli.waypoints = true;
                    }
                }
                */
                
            }
        }
        else
        {
            m_enemy.RemoveTarget(); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        Sight();
    }

    
}
