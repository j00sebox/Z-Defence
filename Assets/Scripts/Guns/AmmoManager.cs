using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static int currentAmmo;
    
    public static int[] guns;

    public GunDisplay gunDisplay;

    void Start()
    {
        guns = new int[5];
    }

    void Update()
    {
        switch(gunDisplay.currentWeapon)
        {
            case Guns.Weapons.Pistol:
                currentAmmo = guns[(int)Guns.Weapons.Pistol];
                break;

            case Guns.Weapons.AssaultRifle:
                currentAmmo = guns[(int)Guns.Weapons.AssaultRifle];
                break;

            case Guns.Weapons.SubmachineGun:
                currentAmmo = guns[(int)Guns.Weapons.SubmachineGun];
                break;

            case Guns.Weapons.Shotgun:
                currentAmmo = guns[(int)Guns.Weapons.Shotgun];
                break;

            case Guns.Weapons.RocketLauncher:
                currentAmmo = guns[(int)Guns.Weapons.RocketLauncher];
                break;
        }   
    }

}
