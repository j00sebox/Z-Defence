using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadout : MonoBehaviour
{

    public Guns.Weapons[] loadout;

    // Start is called before the first frame update
    void Awake()
    {
        loadout = new Guns.Weapons[2];
        loadout[0] = Guns.Weapons.Pistol;
    }

    public void ChangeLoadout(Guns.Weapons weapon1, Guns.Weapons weapon2)
    {
        loadout[0] = weapon1;
        loadout[1] = weapon2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
