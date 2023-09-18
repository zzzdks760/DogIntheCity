using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashbox : MonoBehaviour
{
    public corgiround corgiround;
    public difficulty difficulty = null;
    public GameObject[] trashfood;
    public int trashfoodIndexs = 0;
    public int trashran = 0;
    public GameObject CreatePoint;


    void Start()
    {
        corgiround = GameObject.Find("CorgiCollder").GetComponent<corgiround>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "land")
        {
            trashran =  UnityEngine.Random.Range(0, 5);
            if(trashran == 4)
            {
                trashfoodIndexs =  UnityEngine.Random.Range(0, 5);
                Instantiate(trashfood[trashfoodIndexs], CreatePoint.transform.position, Quaternion.identity);
            }
            difficulty.difscore += 0.2f;
            if(UnityEngine.Random.Range(0, 5) == 1)
            {
                if(corgiround.trashmapscount == 0 || corgiround.trashmapscount == 1)
                {
                    Instantiate(trashfood[5], CreatePoint.transform.position, Quaternion.identity);
                    corgiround.trashmapscount++;
                }
            }
        }
    }
}
