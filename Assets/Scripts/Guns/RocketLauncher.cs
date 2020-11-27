using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Guns
{
    public float rocketVel = 25f;

    public GameObject muzzlePrefab;
    public GameObject muzzlePosition;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    public override void Shoot()
    {
        var flash = Instantiate(muzzlePrefab, muzzlePosition.transform);

        // instantiate actual rocket
        if (projectilePrefab != null)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
            newProjectile.GetComponent<Rigidbody> ().AddForce(newProjectile.transform.forward * rocketVel);
        }

        AmmoManager.guns[(int)weaponType].amount--;
    }

    public override void DisableEffects ()
    {

    }
}
