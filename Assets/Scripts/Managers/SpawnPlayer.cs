using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    int menu = 0;
    int local = 1;
    int networked = 2;
    int sceneIndex;

    bool activeOnLoad;

    [SerializeField]
    GameObject localPlayer;
    [SerializeField]
    GameObject networkedPlayer;

    Transform localspawnPos;

    

    // Use this for initialization
    void Start()
    {

        if (SceneManager.GetActiveScene().name != "Menu")
        {
            gameObject.SetActive(true);
            GameObject refr = GameObject.FindGameObjectWithTag("LocalSpawn");
            localspawnPos = refr.transform;
        }
        else
        {
            gameObject.SetActive(false);
        }


        if (SceneManager.GetActiveScene().name == "Local")
            {
                Instantiate(localPlayer, localspawnPos);
            }
            else if (SceneManager.GetActiveScene().name == "Networked")
        {
                Instantiate(networkedPlayer, localspawnPos);
            }
        }
}

