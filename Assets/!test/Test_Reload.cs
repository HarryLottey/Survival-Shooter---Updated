using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponSystem))]
public class Test_Reload : Test
{
    private WeaponSystem weapon;
    int oldAmmo;

    // Use this for initialization
    void Start()
    {
        weapon = GetComponent<WeaponSystem>();

        oldAmmo = weapon.currentAmmo; // old ammo = magazine of current weapon

        weapon.CheckFire(); // Firing takes off 1 bullet
    }

    protected override void Check()
    {
       
        int currentAmmo = weapon.currentAmmo;
        
        if (currentAmmo < (oldAmmo))
        {
            IntegrationTest.Pass(gameObject);
        }
        else
        {
            IntegrationTest.Fail(gameObject);
        }
    }
}
