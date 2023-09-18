using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sight : MonoBehaviour
{
    //[SerializeField] float m_angle = 0f;//시야의 각도
    [SerializeField] float m_distance = 0f;//시야 한계거리
    [SerializeField] LayerMask m_layerMask = 0;//타겟의 레이어검출
    [SerializeField] EnemyAI m_enemy = null;
    public slide slide;
    public float catcherslide = 0.08f;
    public colli colli = null;
    public float catcherspeed = 0.005f;
    public difficulty diff;
    public Image chaseline; //추적당할 시 테두리
    Animator _animator;


    void Start()
    {
        diff = GameObject.Find("CorgiCollder").GetComponent<difficulty>();
        slide = GameObject.Find("slide").GetComponent<slide>();
        _animator = this.GetComponent<Animator>();
    }

    void View()
    {
        //일정 반경내에있는 플레이어의 collider검출 (**"플레이어 인식"은 m_distance부터)
        Collider[] t_cols = Physics.OverlapSphere(transform.position, m_distance, m_layerMask);
        //검출되었다면
        if (t_cols.Length > 0)
        {
            //player의 transform정보를 받아온다.
            Transform t_tfPlayer = t_cols[0].transform;
            //Player와 Enemy사이의 벡터를 구한다.
            Vector3 vectorBetween = t_tfPlayer.position - transform.position;
            //Player와 Enemy사이의 벡터 크기를 구한다.
            float distance = Vector3.Magnitude(vectorBetween);
            if (distance < 18) //** Player와 Enemy 사이의 거리가 15보다 작아졌을때 "추적시작"
            {
                Vector3 N_vectorBetween = vectorBetween.normalized;
                float view = Vector3.Dot(N_vectorBetween, transform.forward);
                if(view > 0.5)
                {
                    chaseline.enabled = true; //추적당할 시 테두리
                    m_enemy.SetTarget(t_tfPlayer);////////
                    transform.LookAt(t_tfPlayer);//player 바라보기
                    transform.position = Vector3.MoveTowards(transform.position, t_tfPlayer.position, catcherspeed);//어떤위치로 이동+속도
                    
                    _animator.SetFloat("Blend", catcherspeed * 12.0f, 0.1f, Time.deltaTime);
                    colli.waypoints = true;
                }
            }
            else
            {
                chaseline.enabled = false; //추적당할 시 테두리
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
        catcherslide = slide.a/500.0f;
        View();
        if(diff.score == 1)
        {
            catcherspeed = catcherslide;
        }
        else if(diff.score == 2)
        {
            catcherspeed = catcherslide + 0.02f;
        }
        else if(diff.score == 3)
        {
            catcherspeed = catcherslide + 0.04f;
        }
        else if(diff.score == 4)
        {
            catcherspeed = catcherslide + 0.06f;
        }
        else if(diff.score == 5)
        {
            catcherspeed = catcherslide + 0.07f;
        }
    }
}
