using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDisplay : MonoBehaviour
{
    public GameObject[] gunPrefabs; // list of the gun prefabs

    public Loadout loadout;

    public GameObject player;

    GameObject gun;

    int currentLoadoutIndex = 0;

    public Guns.Weapons currentWeapon;

    public void SpawnWeapon()
    {
        // if player already has a gun displayed it needs to be destroyed first
        if(gun != null)
        {
            Destroy(gun);
        }
        // get reference for the fp cam
        Transform cam = player.GetComponentsInChildren<Transform> ()[1];
        gun = Instantiate(gunPrefabs[(int)loadout.loadout[currentLoadoutIndex]], 
        // uses camera position, forward vector, right vector, and -up to put the gun in the right position, the gun also has it's own offset since some prefabs need extra adjustment
        cam.transform.position + cam.transform.forward - cam.transform.up*0.5f + cam.transform.right * gunPrefabs[(int)loadout.loadout[currentLoadoutIndex]].GetComponentInChildren<Guns>().offset, 
        // needs the current camera rotation and the prefabs set rotation to put it in a fixed position everytime
        cam.transform.rotation * gunPrefabs[(int)loadout.loadout[currentLoadoutIndex]].transform.rotation);
        gun.transform.parent = cam.transform; // make the camera it's parent
        player.GetComponent<PlayerShooting>().NewRef(gun); // give the shooting script the reference the the new gun object
    }

    void SwapWeapon()
    {
        // find which gun in the loadout needs to be displayed
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
