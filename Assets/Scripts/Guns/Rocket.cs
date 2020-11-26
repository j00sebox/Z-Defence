using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    public float speed = 100;

    public int damage = 80;

    public LayerMask collisionLayerMask;

    // --- Explosion VFX ---
    public GameObject rocketExplosion;

    // --- Projectile Mesh ---
    public MeshRenderer projectileMesh;

    // --- Script Variables ---
    private bool targetHit;

    // --- Audio ---
    public AudioSource inFlightAudioSource;

    // --- VFX ---
    public ParticleSystem disableOnHit;


    // Update is called once per fram
    void OnCollisionEnter(Collision other)
    {

         // --- Explode when hitting an object and disable the projectile mesh ---
        Explode();

        ZombieHealth zh = other.collider.gameObject.GetComponent<ZombieHealth> ();
        if(zh != null)
        {
            zh.TakeDamage(damage, Vector3.zero);
        }


        // --- Destroy this object after 2 seconds. Using a delay because the particle system needs to finish ---
        Destroy(gameObject);
    }

    void Explode()
    {
        // --- Instantiate new explosion option. I would recommend using an object pool ---
        GameObject newExplosion = Instantiate(rocketExplosion, transform.position, rocketExplosion.transform.rotation);
    }
}
