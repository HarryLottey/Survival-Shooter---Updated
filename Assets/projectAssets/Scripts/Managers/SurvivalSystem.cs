using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurvivalSystem : MonoBehaviour
{
    public float scoreTimer; // This value reads how long in seconds you lasted during the game.
    public float lifeTimer = 120f; // If this timer hits zero game over (lore reasons i dunno)
    public string lifeTimerVisual; // GUI Representation;
    public bool blessed;
    public bool gameOver;
    public GUISkin skin1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Scene test = SceneManager.GetActiveScene(); // Store current scene
        Scene test1 = SceneManager.GetSceneByName("Menu"); // store menu scene
        if (test == test1) // If current scene is the menu
        {
            gameObject.SetActive(false); // Disable UI / conflicting statements
        }

        if (gameOver == false)
        scoreTimer += Time.deltaTime;

        if(blessed == false) // You do not have this powerup by default, you will lose time!
        lifeTimer -= Time.deltaTime;

        if (blessed == true)
            lifeTimer -= Time.deltaTime / 2; // Half the speed

        // Stop time when gameis over
        if(lifeTimer <= 0)
        {
            Time.timeScale = 0;
            gameOver = true;

        }

    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        GUI.skin = skin1;
        if (gameOver == false)
        {
            GUI.Label(new Rect(scrW * 7.5f, scrH * 6, scrW * 3, scrH * 2), "Time Until Corruption: \n (Lose Game) " + lifeTimer.ToString("f0")); // Display timer with no decimal places
        }
        else
        {
            GUI.Label(new Rect(scrW * 7.5f, scrH * 6, scrW * 3, scrH * 2), "Game Over!!!"); // let player know they lost
        }        
       

    }

}
