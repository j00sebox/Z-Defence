using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDisplay : MonoBehaviour
{
    public GameObject[] gunPrefabs;

    public Loadout loadout;

    public GameObject player;

    GameObject gun;

    int currentLoadoutIndex = 0;

    public Guns.Weapons currentWeapon;

    public void SpawnWeapon()
    {
        if(gun != null)
        {
            Destroy(gun);
        }
        Transform cam = player.GetComponentsInChildren<Transform> ()[1];
        gun = Instantiate(gunPrefabs[(int)loadout.loadout[currentLoadoutIndex]], 
        cam.transform.position + cam.transform.forward - cam.transform.up*0.5f + cam.transform.right * gunPrefabs[(int)loadout.loadout[currentLoadoutIndex]].GetComponentInChildren<Guns>().offset, 
        cam.transform.rotation * gunPrefabs[(int)loadout.loadout[currentLoadoutIndex]].transform.rotation);
        gun.transform.parent = cam.transform;
        player.GetComponent<PlayerShooting>().NewRef(gun);
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

        currentWeapon = loadout.loadout[currentLoadoutIndex];
    }
}
