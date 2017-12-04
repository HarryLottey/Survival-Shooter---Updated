using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Weapon
{
    [SerializeField]
    Camera cam;

    
    public float blessDuration = 30f;
    public float timer;
    Light glow;
    public float fireDistance;
    public LayerMask attackable; // Weapon raycasts on this layer


    // Use this for initialization
    void Awake()
    {
        
        glow = gameObject.GetComponentInChildren<Light>();
        cam = Camera.main;
        if(attackable != 1 << LayerMask.NameToLayer("enemy")) // 1 << 8
            attackable = 1 << LayerMask.NameToLayer("enemy"); // Set our layer to enemy if it does not by default.
    }

    public override void Fire(float x)
    {
        RaycastHit hit;

        if(ammo > 0)
        {
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, fireDistance))
            {
                ammo--; // Reduce our ammo once the ray has been fired

                if(hit.transform.gameObject.layer == LayerMask.NameToLayer("enemy")) // If we hit and enemy layer, do stuff
                {
                    Enemy kill = hit.transform.GetComponent<Enemy>();
                    kill.health -= damage;
                    
                }
                
            }
        }
       
    }

    private void OnDrawGizmos()
    {
        if(Camera.main != null)
            Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * fireDistance);
    }

    public override void Reload()
    {
      
            StartCoroutine(RevolveReload());
            if (ammo == maxAmmo)
                StopCoroutine(RevolveReload());
        
        
    }

   

    // Update is called once per frame
    void Update()
    {
        
        if(ammo > maxAmmo)
        {
            StopAllCoroutines();
            ammo = maxAmmo;
        }

        if (blessedWeapon)
        {
            timer += Time.deltaTime;
            glow.intensity = 2.16f;
            damage = 115;
            fireInterval = 0.6f;
            reloadSpeed = 1.5f;

            if (timer >= blessDuration)
                blessedWeapon = false;

        }
        else
        {
            glow.intensity = 0;
            reloadSpeed = 4f;
            damage = 45;
            fireInterval = 0.3f;
        }

        
        if(ammo < maxAmmo)
        Reload();
    }

    IEnumerator RevolveReload()
    {
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        yield return new WaitForSeconds(0.575f);
        ammo += 1;
        // revisit when I have time to make it proper
    }

   
}
