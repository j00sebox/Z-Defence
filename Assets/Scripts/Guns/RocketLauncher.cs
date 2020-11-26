using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Guns
{

    public AudioClip GunShotClip;
    public AudioSource source;
    public Vector2 audioPitch = new Vector2(.9f, 1.1f);

    public float rocketVel = 25f;

    public GameObject muzzlePrefab;
    public GameObject muzzlePosition;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
         if(source != null) source.clip = GunShotClip;
    }

    public override void Shoot()
    {
        var flash = Instantiate(muzzlePrefab, muzzlePosition.transform);

        if (projectilePrefab != null)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
            newProjectile.GetComponent<Rigidbody> ().AddForce(newProjectile.transform.forward * rocketVel);
        }

        if (source != null)
        {
            if(source.transform.IsChildOf(transform))
            {
                source.Play();
            }
            else
            {
                // --- Instantiate prefab for audio, delete after a few seconds ---
                AudioSource newAS = Instantiate(source);
                if ((newAS = Instantiate(source)) != null && newAS.outputAudioMixerGroup != null && newAS.outputAudioMixerGroup.audioMixer != null)
                {
                    // --- Change pitch to give variation to repeated shots ---
                    newAS.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", Random.Range(audioPitch.x, audioPitch.y));
                    newAS.pitch = Random.Range(audioPitch.x, audioPitch.y);

                   
                    newAS.PlayOneShot(GunShotClip);

                    
                    Destroy(newAS.gameObject, 4);
                }
            }
            
        }
    }

    public override void DisableEffects ()
    {

    }
}
