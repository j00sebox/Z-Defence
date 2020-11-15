﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDisplay : MonoBehaviour
{
    public GameObject[] gunPrefabs;

    public Loadout loadout;

    public GameObject player;

    GameObject gun;

    int currentLoadoutIndex = 0;

    public void SpawnWeapon()
    {
        if(gun != null)
        {
            Destroy(gun);
        }
        gun = Instantiate(gunPrefabs[(int)loadout.loadout[currentLoadoutIndex]], player.transform.position + player.transform.forward + player.transform.right, player.transform.rotation * gunPrefabs[(int)loadout.loadout[currentLoadoutIndex]].transform.rotation);
        gun.transform.parent = player.GetComponentsInChildren<Transform> ()[2].transform;
    }

    void SwapWeapon()
    {
        if (currentLoadoutIndex == 0)
        {
            currentLoadoutIndex = 1;
        }
        else
        {
            currentLoadoutIndex = 0;
        }

        SpawnWeapon();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwapWeapon();
        }
    }
}