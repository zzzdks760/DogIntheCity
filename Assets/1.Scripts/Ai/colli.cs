using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colli : MonoBehaviour
{
    public bool waypoints = true;
    //public bool once = false; // 추가한거
    void OnTriggerEnter(Collider other)
    {
        //if (once == false) //추가한거
        //{
            if (other.gameObject.CompareTag("waypoint"))
            {
                waypoints = true;
                //once = true; //추가한거
            }
        //}
    }

    // void OnTriggerExit(Collider other)
    // {
    //     if (once == true) //else문 다 추가한거
    //     {
    //         if (other.gameObject.CompareTag("waypoint"))
    //         {
    //             once = false;

    //         }
    //     }
    // }
}
