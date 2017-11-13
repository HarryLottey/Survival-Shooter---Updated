using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// Player Controller.
    /// 

    public CharacterController charMovement;
    public GameObject playerEyes;
    Vector3 moveDirection;

    [Header("Character Stats")]
    public float movementSpeed = 10f;
    public float jumpSpeed;
    public float gravity = 20f;

    public float mouseSensitivity = 10f;

    private bool jump = false;

    void Start()
    {
        playerEyes = GameObject.FindGameObjectWithTag("Eyes");
    }

    
    void Update()
    {
       
    }

    // Player Movement using settings for PC keyboard
     public void KeyboardMove(float h, float v)
    {
        // Put our axis' into a Vector3
        moveDirection = new Vector3(h, 0, v); // X = left and right | Z = front and back

        // Apply movement
        moveDirection = transform.rotation * moveDirection; // Rotate locally
        moveDirection *= movementSpeed;

        if(jump)
        {
            moveDirection.y = jumpSpeed;
            jump = false;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        
        charMovement.Move(moveDirection * Time.deltaTime);

    }
    
    // Jump Keyboard
     public void Jump(bool j)
    {
        if (charMovement.isGrounded)
        {
            jump = j;
        }
    }

    public void CameraLook(float mX, float mY)
    {
        

      // transform.localEulerAngles = new Vector3(mY = Mathf.Clamp(-mY, -52f, 52f), mX, transform.localEulerAngles.z);

        transform.Rotate(0, mX, 0); // Mouse X rotation: rotates camera left and right.
        playerEyes.transform.Rotate(mY = Mathf.Clamp(-mY, -52f, 52f), 0, 0); // Mouse Y rotation: rotates camera up and down without rotating the character model.

        
    }

    // Player movement using the settings for Gamepad
     public void GamepadMove(float h, float v)
    {
        moveDirection = new Vector3(h, 0, v); // X = left and right | Z = front and back

        // Apply movement
        moveDirection = transform.rotation * moveDirection; // Rotate locally
        moveDirection *= movementSpeed;
        moveDirection.y -= gravity * Time.deltaTime;

        charMovement.Move(moveDirection * Time.deltaTime);
    }
}
