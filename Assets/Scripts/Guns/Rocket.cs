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

    // --- VFX ---
    public ParticleSystem disableOnHit;


    // Update is called once per fram
    void OnCollisionEnter(Collision other)
    {

         // explode when it hits something
        Explode();

        ZombieHealth zh = other.collider.gameObject.GetComponent<ZombieHealth> ();
        if(zh != null)
        {
            zh.TakeDamage(damage, Vector3.zero);
        }


        // destroy
        Destroy(gameObject);
    }

    void Explode()
    {
        // create new explosion
        GameObject newExplosion = Instantiate(rocketExplosion, transform.position, rocketExplosion.transform.rotation);

        // destroy the explosion object after a few seconds
        Destroy(newExplosion, 2f);
    }
}
