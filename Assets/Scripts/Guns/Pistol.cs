﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Guns
{
    Ray shootRay = new Ray();
    RaycastHit shootHit;

    LineRenderer gunLine;

    void Awake()
    {
        gunLine = GetComponent <LineRenderer> ();
    }

    public override void Shoot()
    {
        // Enable the lights.
        // gunLight.enabled = true;

        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition (0, transform.position);

        // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // Perform the raycast against gameobjects on the shootable layer and if it hits something...
        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            ZombieHealth zHealth = shootHit.collider.GetComponent<ZombieHealth> ();

            if(zHealth != null)
            {
                zHealth.TakeDamage(damagePerHit, shootHit.point);
            }
            // Set the second position of the line renderer to the point the raycast hit.
            gunLine.SetPosition (1, shootHit.point);
        }
        // If the raycast didn't hit anything on the shootable layer...
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
        }
    }

    public override void DisableEffects ()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        //gunLight.enabled = false;
    }

}