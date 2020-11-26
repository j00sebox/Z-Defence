using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public static int currentAmmo;

    public struct ammoProperties
    {
        public int amount;
        public int maxAmmo;
    }    
    public static ammoProperties[] guns;

    public GunDisplay gunDisplay;

    void Start()
    {
        guns = new ammoProperties[5];

        guns[0].maxAmmo = 150;
        guns[1].maxAmmo = 250;
        guns[2].maxAmmo = 300;
        guns[3].maxAmmo = 30;
        guns[4].maxAmmo = 10;

        guns[0].amount = guns[0].maxAmmo;
    }

    void Update()
    {
        switch(gunDisplay.currentWeapon)
        {
            case Guns.Weapons.Pistol:
                currentAmmo = guns[(int)Guns.Weapons.Pistol].amount;
                break;

            case Guns.Weapons.AssaultRifle:
                currentAmmo = guns[(int)Guns.Weapons.AssaultRifle].amount;
                break;

            case Guns.Weapons.SubmachineGun:
                currentAmmo = guns[(int)Guns.Weapons.SubmachineGun].amount;
                break;

            case Guns.Weapons.Shotgun:
                currentAmmo = guns[(int)Guns.Weapons.Shotgun].amount;
                break;

            case Guns.Weapons.RocketLauncher:
                currentAmmo = guns[(int)Guns.Weapons.RocketLauncher].amount;
                break;
            default:
                currentAmmo = 1;
                break;
        }   
    }

}
