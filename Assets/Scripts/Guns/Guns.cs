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

    public float timeBetweenShots;

    public float range;

    public int shootableMask;

    public float effectsDisplayTime;

    void Start()
    {
        shootableMask = LayerMask.GetMask ("Shootable");
    }

    public abstract void Shoot();

    public abstract void DisableEffects();
}
