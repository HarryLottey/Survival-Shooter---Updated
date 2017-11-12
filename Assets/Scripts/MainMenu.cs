using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class MainMenu : NetworkBehaviour
{
    GameObject mpMenu;

    // Use this for initialization
    void Start()
    {
        mpMenu = GameObject.Find("MPMenu");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        if(GUI.Button(new Rect(6*scrW, 2*scrH, 4*scrW, 2*scrH), "Local Game"))
        {
            SceneManager.LoadScene(1); // Local Scene
        }

        if (GUI.Button(new Rect(6 * scrW, 4 * scrH, 4 * scrW, 2 * scrH), "Mp Game"))
        {
            

        }

    }

}
