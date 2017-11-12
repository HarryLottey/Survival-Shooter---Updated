using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePauseMenu : MonoBehaviour
{

    public bool paused;
    bool goMP;
    Scene local;
    Scene mP;
    AsyncOperation asyncLoad;

    // Use this for initialization
    void Start()
    {
        local = SceneManager.GetSceneByName("Local");
        mP = SceneManager.GetSceneByName("Networked");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("gPause"))
        {
            paused = !paused;
            
        }

        if (paused)
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else
        {
            Time.timeScale = 1;
            Cursor.visible = false;
        }

        if (goMP) // Unecessary
        {
            if (asyncLoad.isDone)
            {
                SceneManager.MergeScenes(local, mP);
            }
        }
    }

    

    private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;
        if (paused)
        {
            
            if (GUI.Button(new Rect(6 * scrW, 2 * scrH, 4 * scrW, 2 * scrH), "Resume"))
            {
                paused = false;
            }

            if (GUI.Button(new Rect(6 * scrW, 4 * scrH, 4 * scrW, 2 * scrH), "HostMultiplayerGame"))
            {
               asyncLoad = SceneManager.LoadSceneAsync(2);
                
            }

            if (GUI.Button(new Rect(6 * scrW, 6 * scrH, 4 * scrW, 2 * scrH), "Exit to Main Menu"))
            {
                SceneManager.LoadScene(0); // Main Menu
            }
        }
        
      
    }
}
