using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedUserController : NetworkBehaviour
{

    public PlayerController playerInput;
    // Keyboard
    float kH;
    float kV;
    bool j;
    float mouseX;
    float mouseY;

    // Use this for initialization
    void Start()
    {
        playerInput = GetComponentInChildren<PlayerController>();

        Cursor.visible = false;

        

    }

    // Update is called once per frame
    void Update()
    {
        // if (!isLocalPlayer) return;

        kH = Input.GetAxis("Horizontal");
        kV = Input.GetAxis("Vertical");
        j = Input.GetButton("Jump");

        // Mouse Look
        float mouseX = Input.GetAxis("Mouse X") * playerInput.mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * playerInput.mouseSensitivity;

        playerInput.KeyboardMove(kH, kV);
        playerInput.CameraLook(mouseX, mouseY);

    }

    

}
