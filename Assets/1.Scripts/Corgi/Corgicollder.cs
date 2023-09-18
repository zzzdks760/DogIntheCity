using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Corgicollder : MonoBehaviour
{
    public PlayerMovement pm = null;
    public Controller ctroll = null;
    public GameObject nearObject, maps;
    public Vector3 createmap;
    public int nearfood;
    public bool park = false;
    public bool market = false;
    public bool printflyers = false;
    public bool home = false;
    public bool badfoods = false;
    public int countdogmaps = 0;

    public AudioSource audiosource;
    public AudioClip hitclip;

    void OnTriggerStay(Collider other) 
    {

        if(other.tag == "apple")
        {
            nearfood = 1;
            nearObject = other.gameObject;
        }
        else if (other.tag == "banana")
        {
            nearfood = 2;
            nearObject = other.gameObject;
        }
        else if(other.tag == "bread")
        {
            nearfood = 14;
            nearObject = other.gameObject;
        }
        else if(other.tag == "pepper")
        {
            nearfood = 13;
            nearObject = other.gameObject;
        }
        else if(other.tag == "leek")
        {
            nearfood = 8;
            nearObject = other.gameObject;
        }
        else if(other.tag == "melon")
        {
            nearfood = 6;
            nearObject = other.gameObject;
        }
        else if(other.tag == "cheese")
        {
            nearfood = 7;
            nearObject = other.gameObject;
        }
        else if(other.tag == "tomato")
        {
            nearfood = 5;
            nearObject = other.gameObject;
        }
        else if(other.tag == "asparagus")
        {
            nearfood = 9;
            nearObject = other.gameObject;
        }
        else if(other.tag == "garlic")
        {
            nearfood = 10;
            nearObject = other.gameObject;
        }
        else if(other.tag == "beef")
        {
            nearfood = 11;
            nearObject = other.gameObject;
        }
        else if(other.tag == "bone beef")
        {
            nearfood = 12;
            nearObject = other.gameObject;
        }
        else if(other.tag == "orange")
        {
            nearfood = 4;
            nearObject = other.gameObject;
        }
        else if(other.tag == "artichoke")
        {
            nearfood = 3;
            nearObject = other.gameObject;
        }
        else if(other.tag == "perry")
        {
            nearfood = 15;
            nearObject = other.gameObject;
        }
        else if(other.tag == "carots")
        {
            nearfood = 16;
            nearObject = other.gameObject;
        }
        else if(other.tag == "salad")
        {
            nearfood = 17;
            nearObject = other.gameObject;
        }
        else if(other.tag == "chicken")
        {
            nearfood = 18;
            nearObject = other.gameObject;
        }
        else if(other.tag == "burger")
        {
            nearfood = 19;
            nearObject = other.gameObject;
        }
        else if(other.tag == "hotdog")
        {
            nearfood = 20;
            nearObject = other.gameObject;
        }
        else if(other.tag == "park")
        {
            park = true;
            pm.jumpPower = 7.0f;
        }
        else if(other.tag == "market")
        {
            market = true;
        }
        else if(other.tag == "printflyers")
        {
            printflyers = true;
        }
        else if(other.tag == "home")
        {
            home = true;
        }
        else if(other.tag == "badapple")
        {
            nearfood = 21;
            nearObject = other.gameObject;
            badfoods = true;
        }
        else if(other.tag == "badbanana")
        {
            nearfood = 22;
            nearObject = other.gameObject;
            badfoods = true;
        }
        else if(other.tag == "badartichoke")
        {
            nearfood = 23;
            nearObject = other.gameObject;
            badfoods = true;
        }
        else if(other.tag == "badorange")
        {
            nearfood = 24;
            nearObject = other.gameObject;
            badfoods = true;
        }
        else if(other.tag == "badtomato")
        {
            nearfood = 25;
            nearObject = other.gameObject;
            badfoods = true;
        }
        else if(other.tag == "jumping")
        {
            pm.jumpPower = 7.0f;
        }
        else if(other.tag == "maps")
        {
            nearfood = 26;
            nearObject = other.gameObject;
        }
        else if(other.tag == "dog")
        {
            if(pm.atc == true)
            {
                pm.atc = false;
                audiosource.PlayOneShot(hitclip);
                ctroll._animator.SetLayerWeight(1, 0.0f);
                other.GetComponent<Animator>().SetTrigger("dohit");
                other.GetComponent<NavMeshAgent>().speed = 0.0f;
                if(ctroll.clone1 == true && other.gameObject.name == "Corgi_clone1" && countdogmaps == 0)
                {
                    dogmapcreate();
                }
                if(ctroll.clone2 == true && other.gameObject.name == "Corgi_clone2" && countdogmaps == 0)
                {
                    dogmapcreate();
                }
                if(ctroll.clone3 == true && other.gameObject.name == "Corgi_clone3" && countdogmaps == 0)
                {
                    dogmapcreate();
                }
                if(ctroll.clone4 == true && other.gameObject.name == "Corgi_clone4" && countdogmaps == 0)
                {
                    dogmapcreate();
                }
            }
        }
    }

    void dogmapcreate()
    {
        createmap = ctroll.clone[ctroll.cnt].transform.TransformPoint(new Vector3(0.3f, 0.0f, 0.0f));
        Instantiate(maps, createmap, Quaternion.identity);
        Destroy(ctroll.maps[ctroll.cnt]);
        countdogmaps++;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "food" || other.tag == "badfood")
        {
            nearfood = 0;
            nearObject = null;
        }
        else if(other.tag == "park")
        {
            park = false;
        }
        else if(other.tag == "market")
        {
            market = false;
        }
        else if(other.tag == "printflyers")
        {
            printflyers = false;
        }
        else if(other.tag == "maps")
        {
            nearfood = 0;
            nearObject = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "enemy")
        {
            LoadingSceneManager.LoadScene("gmaeover");
        }
    }
}
