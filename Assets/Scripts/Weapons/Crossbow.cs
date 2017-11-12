using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : Weapon
{



    public Transform projectileOrigin;
    public GameObject boltPrefab;
    Light glow;
    public float fireDistance;
    public LayerMask attackable; // Weapon raycasts on this layer


    // Use this for initialization
    void Awake()
    {
        glow = gameObject.GetComponentInChildren<Light>();

        if (attackable != 1 << LayerMask.NameToLayer("enemy")) // 1 << 8
            attackable = 1 << LayerMask.NameToLayer("enemy"); // Set our layer to enemy if it does not by default.
    }

    private void Start()
    {
        boltPrefab = Resources.Load("ArrowTemp") as GameObject;
    }

    public override void Fire(float x)
    {
       
        if (ammo > 0)
        {
            ammo--;
            Instantiate(boltPrefab, projectileOrigin.transform.position, transform.localRotation);                           
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * fireDistance);
    }

    public override void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || ammo <= 0 || Input.GetButtonDown("gReload"))
        { // Manual reload, or when we are out of ammo
            StartCoroutine(CrossbowReload());
            if (ammo >= maxAmmo)
                StopCoroutine(CrossbowReload());
        }

    }



    // Update is called once per frame
    void Update()
    {
        if (blessedWeapon)
        {
            glow.intensity = 2.16f;
            damage = 115;
            fireInterval = 0.6f;
            reloadSpeed = 1.5f;
        }
        else
        {
            glow.intensity = 0;
            reloadSpeed = 4f;
            damage = 45;
            fireInterval = 0.3f;
        }


        if (ammo < maxAmmo)
            Reload();

        if (ammo > maxAmmo)
        {
            StopAllCoroutines();
            ammo = maxAmmo;
        }
    }

    IEnumerator CrossbowReload()
    {
        yield return new WaitForSeconds(1.4f);
        ammo += 1;
        
        
        // revisit when I have time to make it proper
    }

}
