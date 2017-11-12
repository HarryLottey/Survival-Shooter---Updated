using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAction : MonoBehaviour
{

    Weapon[] equippedWeapons;
    Weapon currentWeapon;
    int wepIndex;
    RaycastHit interaction;
    float interactionDistance = 5f;

    // Use this for initialization
    void Start()
    {

        equippedWeapons = GetComponentsInChildren<Weapon>(true);

    }

    // Update is called once per frame
    void Update()
    {
        WeaponSystem indexRef = gameObject.GetComponent<WeaponSystem>();
        currentWeapon = equippedWeapons[indexRef.weaponIndex];

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out interaction, interactionDistance))
        {

            if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("gUse"))
            {
                // IF we hit an object that is interactable
                if (interaction.collider.gameObject.layer == LayerMask.NameToLayer("Interactable"))
                {
                    string objName = interaction.transform.gameObject.name;

                    if (objName == "Altar")
                    {

                        Altar altrRef = interaction.collider.gameObject.GetComponent<Altar>();
                        Debug.Log(interaction.transform.name);
                        if (currentWeapon.blessedWeapon == false)
                            altrRef.BlessWeapon(currentWeapon);
                    }
                }
            }
        }



    }


 
}
