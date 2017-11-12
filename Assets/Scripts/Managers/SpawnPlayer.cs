using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    int local = 1;
    int networked = 2;
    int sceneIndex;
    
    [SerializeField]
    GameObject localPlayer;
    [SerializeField]
    GameObject networkedPlayer;

    Transform localspawnPos;

    private void Awake()
    {

        sceneIndex = SceneManager.GetActiveScene().buildIndex;

        GameObject refr = GameObject.FindGameObjectWithTag("LocalSpawn");
        localspawnPos = refr.transform;
    }

    // Use this for initialization
    void Start()
    {
        

        if(sceneIndex == local)
        {
            Instantiate(localPlayer, localspawnPos);
        }

        else if (sceneIndex == networked)
        {
            Instantiate(networkedPlayer, localspawnPos);
        }        
    }

    private void Update()
    {
        gameObject.SetActive(true);
    }

}
