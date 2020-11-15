using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDisplay : MonoBehaviour
{
    public GameObject[] gunPrefabs;

    public Loadout loadout;

    GameObject player;

    GameObject gun;

    Guns.Weapons currentWeapon;

    // Start is called before the first frame update
    void Start()
    {
        currentWeapon = loadout.loadout[0];
        
    }

    public void SpawnWeapon()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gun = Instantiate(gunPrefabs[(int)currentWeapon], Vector3.up*3 + Vector3.forward + Vector3.right, gunPrefabs[(int)currentWeapon].transform.rotation);
        gun.transform.parent = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
