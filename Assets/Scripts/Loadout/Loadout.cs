using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour
{
    // array that holds the player's current loadout
    public Guns.Weapons[] loadout;

    
    // Start is called before the first frame update
    void Awake()
    {
        loadout = new Guns.Weapons[2];

        // loadout starts with pistol and fists
        loadout[0] = Guns.Weapons.Pistol;
        loadout[1] = Guns.Weapons.None;
    }
}
