using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserController : MonoBehaviour
{
    /// Apply defined input
    
    
    public PlayerController playerInput;
    public GameObject gameMasterReference;
    InGamePauseMenu pauseboi;
    SurvivalSystem endGameMovement;
    Weapon currentwep;

    // Keyboard
    float kH; 
    float kV; 
    bool j;
    bool gJ; 

    

    // Use this for initialization
    void Start()
    {


        gameMasterReference = GameObject.FindGameObjectWithTag("GM");
        playerInput = GetComponentInChildren<PlayerController>();
        pauseboi = gameMasterReference.GetComponentInChildren<InGamePauseMenu>();
        endGameMovement = gameMasterReference.GetComponentInChildren<SurvivalSystem>();
        Cursor.visible = false;

        
    }

    
    void Update()
    {

        kH = Input.GetAxis("Horizontal");
        kV = Input.GetAxis("Vertical");
        j = Input.GetButton("Jump");
        gJ = Input.GetButton("cJump");

        // Gamepad

        float gH = Input.GetAxis("cHorizontal");
        float gV = Input.GetAxis("cVertical");

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * playerInput.mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * playerInput.mouseSensitivity;

        // Controller look

        float gAxisX = Input.GetAxis("gX") * playerInput.mouseSensitivity;
        float gAxisY = Input.GetAxis("gY") * playerInput.mouseSensitivity;


        if (pauseboi.paused == false && endGameMovement.gameOver == false) // If the game isnt paused, allow input
        {
            

            // Apply Keyboard movement
            playerInput.KeyboardMove(kH, kV);
            playerInput.Jump(j);

            // Apply MouseLook
            playerInput.CameraLook(mouseX, mouseY);

            playerInput.CameraLook(gAxisX, gAxisY);

            // apply gamepad inputs
            playerInput.GamepadMove(gH, gV);


        }

        bool isCyclingWeapon = Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("gSwap");
        if(isCyclingWeapon)
        {
            // Cycke weapon here
            WeaponSystem cycle = gameObject.GetComponent<WeaponSystem>();
            cycle.WeaponSwitching();
        }

        // IF user pressed down space
        if (Input.GetButtonDown("Fire1") || Input.GetAxisRaw("cFire1") > 0)
        {
            Weapon currentWeapon = gameObject.GetComponent<Weapon>();
            Weapon[] equippedWeapons = gameObject.GetComponents<Weapon>();
            WeaponSystem weaponIndex = gameObject.GetComponent<WeaponSystem>();
            
            currentWeapon = equippedWeapons[weaponIndex.weaponIndex];
            currentWeapon.Fire(weaponIndex.weaponIndex);

        }

        /*
        if (Input.GetKeyDown(KeyCode.R) || ammo < 0 || Input.GetButtonDown("gReload"))
        { // Manual reload, or when we are out of ammo
            StartCoroutine(RevolveReload());
            if (ammo == maxAmmo)
                StopCoroutine(RevolveReload());
        }
        */

    }
}
