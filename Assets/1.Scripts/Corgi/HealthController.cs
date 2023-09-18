using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthController : MonoBehaviour
{
    public GameObject heart;
    public int PlayerHealth = 3;

    public Image[] Front;

    private void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if(PlayerHealth <= 0)
        {
            //Restart the game
            //Respawn the Player
        }
        if (PlayerHealth == 3)
        {
            for (int i = 0; i <= Front.Length; i++)
            {
                if (i < PlayerHealth)
                {
                    Front[i].color = Color.white;
                }
            }
        }
        else if (PlayerHealth == 2)
        {
            for (int i = 0; i <= Front.Length-1; i++)
            {
                if (i < PlayerHealth)
                {
                    Front[i].color = Color.white;
                }
                else 
                {
                    Front[i].color = Color.black;
                }
            }
        }
        else if(PlayerHealth == 1)
        {
            for (int i = 0; i <= Front.Length-2; i++)
            {
                if (i < PlayerHealth)
                {
                    Front[i].color = Color.white;
                }
                else
                {
                    Front[i].color = Color.black;
                }
            }
        }
        else if (PlayerHealth == 0)
        {
            if(PlayerHealth == 0)
            {
                LoadingSceneManager.LoadScene("gmaeover");
            } 
        }

    }

    [SerializeField] private int carDamage;
    [SerializeField] private int Heart;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "car")
        {
            Damage();
        }
        else if(collision.collider.tag == "heart")
        {
            heart.SetActive(false);

            if (PlayerHealth < 3)
            {     
                HeartAdd();
            }   
        }
    }

    void Damage()
    {
        PlayerHealth = PlayerHealth - carDamage;
        UpdateHealth();
    }

    void HeartAdd()
    {
        PlayerHealth = PlayerHealth + Heart;
        UpdateHealth();
    }
}