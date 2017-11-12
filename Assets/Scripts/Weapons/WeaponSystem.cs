using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    public int weaponIndex = 0;
    public Weapon[] equippedWeapons;
    Weapon currentWeapon;
    public int currentAmmo;
    



    // Use this for initialization
    void Start()
    {
        equippedWeapons = GetComponentsInChildren<Weapon>(true);
    }

    // Update is called once per frame
    void Update()
    {
        currentAmmo = equippedWeapons[weaponIndex].ammo;
        WeaponSwitching();
        CheckFire();
    }

    // Check if a weapon is firing, and make sure the suitable fire function is ran
    void CheckFire()
    {
        // Set current weapon to the weapon that correlates with index number from heirarcy order
        currentWeapon = equippedWeapons[weaponIndex];
        // IF user pressed down space
        if (Input.GetButtonDown("Fire1") || Input.GetAxisRaw("cFire1") > 0)
        {
            Debug.Log(Input.GetAxisRaw("cFire1").ToString());
            // Fire currentWeapon
            currentWeapon.Fire(currentWeapon.fireInterval);
        }
    }

    #region Weapon Switching
    // Handles weapon switching
    void WeaponSwitching()
    {
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetButtonDown("gSwap"))
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

public abstract class Weapon : MonoBehaviour
{
    private GameObject enemy;
    public bool blessedWeapon; // powered up state, required to defeat special enemies
    public int damage = 30;
    public int ammo = 0;
    public int maxAmmo = 6;
    public float reloadSpeed = 5f;
    public float fireInterval = 0.2f;
    


    public abstract void Fire(float x);
    public virtual void Reload() // when reload is called, set current ammo to full clipsize
    {
        ammo = maxAmmo;
    }

}
