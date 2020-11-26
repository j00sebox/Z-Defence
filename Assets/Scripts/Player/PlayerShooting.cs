using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    Transform cam;

    Transform gun;

    Guns gunScript;

    float timer;

    float timeBetweenMelee = 0.5f;

    

    public int meleeDamage = 5;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentsInChildren<Transform> ()[1];

        gun = cam.GetComponentsInChildren<Transform> ()[1];

        gunScript = gun.GetComponentInChildren<Guns> (); 
    }

    public void NewRef(GameObject gun)
    {
        gunScript = gun.GetComponentInChildren<Guns> ();
        // = gunScript.totalAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(RoundManager.roundStarted && !PauseManager.Paused)
        {
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            if(gunScript != null)
            {
                if (timer >= gunScript.timeBetweenShots && Time.timeScale != 0 && AmmoManager.currentAmmo > 0)
                {
                    if( Input.GetButton("Fire1") )
                    {
                        timer = 0f;
                        gunScript.Shoot();
                    }
                }

                // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
                if(timer >= gunScript.timeBetweenShots * gunScript.effectsDisplayTime)
                {
                    // ... disable the effects.
                    gunScript.DisableEffects();
                }
            }
        }
    }
}
