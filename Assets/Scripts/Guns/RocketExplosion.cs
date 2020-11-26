using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketExplosion : MonoBehaviour
{
    public int damage = 60;

    void OnTriggerEnter(Collider other)
    {
        ZombieHealth zh = other.GetComponent<Collider> ().gameObject.GetComponent<ZombieHealth> ();
        if(zh != null)
        {
            zh.TakeDamage(damage, Vector3.zero);
        }
    }
}
