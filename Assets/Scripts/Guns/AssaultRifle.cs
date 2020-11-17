using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Guns
{
    // Start is called before the first frame update
    void Start()
    {
        weaponType = Weapons.AssaultRifle;
        purchased = false;
    }

    public override void Shoot()
    {
        Debug.Log("AR");
    }

    public override void DisableEffects ()
    {

    }
    
}
