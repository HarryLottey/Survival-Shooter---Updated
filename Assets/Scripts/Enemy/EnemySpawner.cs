using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject spawnPoints;
    [SerializeField]
    List<Transform> children = new List<Transform>();
    public float spawnTimer;
    public float spawnInterval = 10f;
    public GameObject enemyPrefab;   
    public GameObject yo;
    int spawnPointMaxIndex = 8;

  
    // Use this for initialization
    void Start()
    {

        if (SceneManager.GetActiveScene().name != "Menu")
        {
            gameObject.SetActive(true);
            spawnPoints = GameObject.FindGameObjectWithTag("SpawnPoint");
            yo = GameObject.Find("[Group] SpawnPoints");
            yo.GetComponentsInChildren<Transform>();

            foreach (Transform sp in spawnPoints.transform)
            {
                children.Add(sp.transform);
            }

        }
        else
        {
            gameObject.SetActive(false);
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (SceneManager.GetActiveScene().name != "Menu")
        {
              spawnTimer += Time.deltaTime;

        if(spawnTimer > spawnInterval)
        {
            

            for (int i = 0; i < children.Count; i++) 
            {
                Instantiate(enemyPrefab, children[i].transform.localPosition, children[i].localRotation);
                //Instantiate(enemyPrefab, spawnPoints[i]);
                spawnTimer = 0f;
                spawnInterval -= 0.05f;
            }
           
        }

        if (spawnInterval <= 5f)
        {
            spawnInterval = 10f;
        }
        }

      

    }
}
