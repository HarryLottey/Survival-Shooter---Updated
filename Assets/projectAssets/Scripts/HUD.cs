using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{

    public Texture2D revolverIcon;
    public Texture2D crossbowIcon;
    public Texture2D qIcon; // Tells the user what key to press to swap guns
    public Texture2D eIcon; // Interactable Objects Prompt
    public Texture2D gradientIcon;
    public Texture2D healthBar;
    public Texture2D rIcon;
    Texture2D bulletTexture;
    Texture2D bulletTexture2;
    public int rows = 4;
    public float ammoY, ammoX, ammoSpacing, ammoSpacingY, ammoSizeY, ammoSizeX; // Positioning of icons

    GameObject player;
    public WeaponSystem indexRef;

    bool showInteractable;
    bool showReload;


    
   

    // Use this for initialization
    void Start()
    {



        if (SceneManager.GetActiveScene().name != "Menu")
        {
            gameObject.SetActive(true);
            player = GameObject.FindGameObjectWithTag("Player");
            //indexRef = player.GetComponentInParent<WeaponSystem>();
            revolverIcon = Resources.Load("Icons/RevolverIcon") as Texture2D;
            crossbowIcon = Resources.Load("Icons/CrossbowIcon") as Texture2D;
            eIcon = Resources.Load("Icons/Eicon") as Texture2D;
            qIcon = Resources.Load("Icons/Qicon") as Texture2D;
            rIcon = Resources.Load("Icons/Ricon") as Texture2D;
            gradientIcon = Resources.Load("Icons/GradientIcon") as Texture2D;
            bulletTexture = Resources.Load("Icons/Bullet") as Texture2D;
            bulletTexture2 = Resources.Load("Icons/Bolt") as Texture2D;

        }
        else if (SceneManager.GetActiveScene().name == "Menu")
        {
            gameObject.SetActive(false);
        }




    }

    // Update is called once per frame
    void Update()
    {

       

        if (SceneManager.GetActiveScene().name != "Menu")
        {
            Scene test = SceneManager.GetActiveScene(); // Store current scene
            Scene test1 = SceneManager.GetSceneByName("Menu"); // store menu scene

            if (test == test1) // If current scene is the menu
            {
                gameObject.SetActive(false); // Disable UI / conflicting statements
            }

            if (indexRef != null)
            {
                if (indexRef.currentAmmo <= 0)
                {
                    showReload = true;
                }
                else
                {
                    showReload = false;
                }
            }



            if (indexRef != null)
            {
                if (indexRef.weaponIndex == 0)
                {
                    // NOTE(Manny): This should be loaded at start ONLY

                }
                else if (indexRef.weaponIndex == 1)
                {

                }
            }

            RaycastHit hit;
/*
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5, 1 << LayerMask.NameToLayer("Interactable")))
            {
                showInteractable = true;
            }
            else
            {
                showInteractable = false;
            }
            */
        }


    }

   

    void OnGUI()
    {


        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;


        Profiler.BeginSample("Draw Texture");
        for (int x = 0; x < rows; x++) // Row
        {
            for (int y = 0; y < 10; y++) // Column
            {
              //  GUI.DrawTexture(new Rect(ammoX * scrW + (y * (ammoSpacing * scrW)), ammoY * scrH + (x * (ammoSpacingY * scrH)), ammoSizeX * scrW, ammoSizeY * scrH), bulletTexture);
            }
            // Row * 10
        }
        Profiler.EndSample();

        Profiler.BeginSample("Load Image");
        if (indexRef != null)
        {
            // is our editable bullet clip
            for (int i = 0; i < indexRef.currentAmmo; i++)
            {
                // Draw a texture that moves one across for every bullet we have, and moves down with the addition of each new row
                GUI.DrawTexture(new Rect(ammoX * scrW + (i * (ammoSpacing * scrW)), ammoY * scrH + (rows * (ammoSpacingY * scrH)), ammoSizeX * scrW, ammoSizeY * scrH), bulletTexture);
            }
        }
        Profiler.EndSample();

        Profiler.BeginSample("Shows Reload");
        if (showReload)
        {
            GUI.DrawTexture(new Rect(8 * scrW, 4 * scrH, 1.5f * scrW, 1f * scrH), rIcon);
            GUI.Label(new Rect(8.5f * scrW, 5f * scrH, 1.3f * scrW, 1f * scrH), "Reload");
        }
        Profiler.EndSample();

        GUI.DrawTexture(new Rect(13*scrW, 8*scrH, 1.5f*scrW, 1f*scrH), qIcon);

        if(showInteractable == true)
        {
            GUI.DrawTexture(new Rect(8 * scrW, 4 * scrH, 1.5f * scrW, 1f * scrH), eIcon);
            GUI.Label(new Rect(8.5f * scrW, 5f * scrH, 1.3f * scrW, 1f * scrH), "Use");
        }

        if (indexRef != null)
        {
            if (indexRef.weaponIndex == 0)
                GUI.DrawTexture(new Rect(14 * scrW, 8 * scrH, 2 * scrW, 1 * scrH), revolverIcon);

            if (indexRef.weaponIndex == 1)
                GUI.DrawTexture(new Rect(14 * scrW, 8 * scrH, 2 * scrW, 1 * scrH), crossbowIcon);
        }
    }
}
