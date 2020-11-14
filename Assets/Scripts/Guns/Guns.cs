using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guns : MonoBehaviour
{

    public enum Weapons
    {
        Pistol,
        AssaultRifle,
        SubmachineGun,
        Shotgun,
        RocketLauncher

    };

    public Weapons weaponType;

    public bool purchased;

    public float timeBetweenShots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
