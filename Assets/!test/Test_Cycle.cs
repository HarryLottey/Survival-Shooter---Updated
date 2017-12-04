using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponSystem))]
public class Test_Cycle : Test
{
    private WeaponSystem weapon;

    private int oldWeaponIndex = 0;

    // Use this for initialization
    void Start()
    {
        weapon = GetComponent<WeaponSystem>();

        // Record the current weaponIndex
        oldWeaponIndex = weapon.weaponIndex;

        Debug.Log(weapon.weaponIndex);

        // Cycle the weapon
        weapon.CycleWeapon(-1);

        Debug.Log(weapon.weaponIndex);
    }

    protected override void Check()
    {
        int weaponIndex = weapon.weaponIndex;
        if (weaponIndex > oldWeaponIndex)
        {
            IntegrationTest.Pass(gameObject);
        }
        else
        {
            IntegrationTest.Fail(gameObject);
        }
    }
}
