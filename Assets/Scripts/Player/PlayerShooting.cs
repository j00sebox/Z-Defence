using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // first person camera
    Transform cam;

    // gun the player has selected
    Transform gun;

    Guns gunScript;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentsInChildren<Transform> ()[1];

        gun = cam.GetComponentsInChildren<Transform> ()[1];

        gunScript = gun.GetComponentInChildren<Guns> (); 
    }

    // when the player switches weapons this is called to get the reference of the new prefab
    public void NewRef(GameObject gun)
    {
        gunScript = gun.GetComponentInChildren<Guns> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(RoundManager.roundStarted && !PauseManager.Paused)
        {
            // add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            if(gunScript != null)
            {
                // if the time between shots has expired and player has enough ammo
                if (timer >= gunScript.timeBetweenShots && Time.timeScale != 0 && AmmoManager.currentAmmo > 0)
                {
                    // left mouse button
                    if( Input.GetButton("Fire1") )
                    {
                        // reset timer and call that weapons shoot function
                        timer = 0f;
                        gunScript.Shoot();
                    }
                }

                if(timer >= gunScript.timeBetweenShots * gunScript.effectsDisplayTime)
                {
                    gunScript.DisableEffects();
                }
            }
        }
    }
}
