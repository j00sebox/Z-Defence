using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : Guns
{
    Animator anim;

    bool enemyInRange = false;

    SphereCollider meleeRange;

    ZombieHealth enemeyAttacked;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator> ();

        meleeRange = GetComponent<SphereCollider> ();
    }

    public override void Shoot()
    {
        GetComponentInChildren<Fist> ().SetAnim();
        if(enemyInRange)
        {
            ZombieHealth zHealthScript = enemeyAttacked.GetComponent<ZombieHealth> ();
            zHealthScript.TakeDamage(damagePerHit, Vector3.zero);
        }
    }

    public void SetAnim()
    {
        anim.SetTrigger("Punching");
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject obj = other.gameObject;
        enemeyAttacked = obj.GetComponent<ZombieHealth> ();

        if(enemeyAttacked != null)
        {
            enemyInRange = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        enemyInRange = false;
    }
}
