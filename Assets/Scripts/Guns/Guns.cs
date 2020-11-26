using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Guns : MonoBehaviour
{

    public enum Weapons
    {
        Pistol,
        AssaultRifle,
        SubmachineGun,
        Shotgun,
        RocketLauncher,
        None

    };

    public Weapons weaponType;

    public bool purchased;

    public float offset;

    public float timeBetweenShots;

    public float range;

    public int shootableMask;

    public float effectsDisplayTime;

    public int damagePerHit;

    Ray shootRay = new Ray();
    RaycastHit shootHit;

    LineRenderer gunLine;

    public int magSize;

    public int maxAmmo;

    public int totalAmmo;

    public int ammoinMag;

    void Start()
    {
        shootableMask = LayerMask.GetMask ("Shootable");

        gunLine = GetComponentInChildren <LineRenderer> ();

        Setup();
    }

    public virtual void Setup() { }

    public virtual void Shoot()
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
                if(!zHealth.IsDead())
                {
                    zHealth.TakeDamage(damagePerHit, shootHit.point);
                }
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

        AmmoManager.guns[(int)weaponType].amount--;
    }

    public virtual void DisableEffects()
    {
        if(gunLine != null)
        {
            // Disable the line renderer and the light.
            gunLine.enabled = false;
            //gunLight.enabled = false;
        }
        
    }
}
