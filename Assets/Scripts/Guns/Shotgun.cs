using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Guns
{
    public int pelletCount;
    public float spreadAngle;

    float timeBeforeDestroyed = 4;

    public float pelletFireVel = 100f;
    public GameObject pellet;
    public Transform BarrelExit;

    List<Quaternion> pellets;

    void Awake()
    {
        pellets = new List<Quaternion> (new Quaternion[pelletCount]);
    }

    public override void Shoot()
    {
        GameObject p = new GameObject();
        for(int i = 0; i < pelletCount; i++)
        {
            pellets[i] = Random.rotation;
            p = Instantiate(pellet, BarrelExit.position, BarrelExit.rotation);
            Destroy(p, timeBeforeDestroyed);
            p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
            p.GetComponent<Rigidbody>().AddForce(p.transform.forward * pelletFireVel);
        }

        AmmoManager.guns[(int)Guns.Weapons.Shotgun].amount--;
    }

    public override void DisableEffects ()
    {

    }
}
