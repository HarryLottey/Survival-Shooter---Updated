using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedWeaponSystem : NetworkBehaviour
{

    public int weaponIndex = 0;
    public Weapon[] equippedWeapons;




    // Use this for initialization
    void Awake()
    {
        equippedWeapons = GetComponentsInChildren<Weapon>(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
            return;


        if (isLocalPlayer)
        {
            WeaponSwitching();

            if (Input.GetButtonDown("Fire1"))
            {
                Cmd_CheckFire();
                
            }
        }

        
    }

    [Command] void Cmd_CheckFire()
    {
        Rpc_CheckFire();
    }

    // Check if a weapon is firing, and make sure the suitable fire function is ran
    [ClientRpc] void Rpc_CheckFire()
    {
        // Set current weapon to the weapon that correlates with index number from heirarcy order
        Weapon currentWeapon = equippedWeapons[weaponIndex];
        
        currentWeapon.Fire(currentWeapon.fireInterval);
    } 
    

    [Command] void Cmd_CycleWeapon()
    {
        Rpc_CheckFire();
    }

    [ClientRpc] void Rpc_CycleWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CycleWeapon(-1);
        }
    }

    #region Weapon Switching
    // Handles weapon switching
    void WeaponSwitching()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CycleWeapon(-1);
        }
    }
    // Cycles throuhg weapons using amount as an index for selected weapon.
    void CycleWeapon(int amount)
    {
        // SET desired index to weaponIndex + amount
        int desiredIndex = weaponIndex + amount;
        // IF desiredIndex >= length of weapons
        if (desiredIndex >= equippedWeapons.Length)
        {
            // SET desired index to zero
            desiredIndex = 0;
        }
        // ELSE IF desiredIndex < zero
        else if (desiredIndex < 0)
        {
            // SET desiredIndex to length of weapons - 1
            desiredIndex = equippedWeapons.Length - 1;
        }
        // SET weaponIndex to desiredIndex
        weaponIndex = desiredIndex;
        // SwitchWeapon() to weaponIndex
        SwitchWeapon(weaponIndex);
    }

    // Disables all other weapons in the list, and returns the selected one.
    Weapon SwitchWeapon(int weaponIndex)
    {
        // Check if index is outside of bounds.
        if (weaponIndex < 0 || weaponIndex > equippedWeapons.Length)
        {
            return null;
        }
        // Looping through all the weapons
        for (int i = 0; i < equippedWeapons.Length; i++)
        {
            // Get the weapon at index
            Weapon w = equippedWeapons[i];
            // IF index == weapon idex
            if (i == weaponIndex)
            {
                // Activate the weapon
                w.gameObject.SetActive(true);
            }
            // Else
            else
            {
                // Deactivate the weapon
                w.gameObject.SetActive(false);
            }
        }
        // Return selected weapon
        return equippedWeapons[weaponIndex];

        #endregion

    }
}
