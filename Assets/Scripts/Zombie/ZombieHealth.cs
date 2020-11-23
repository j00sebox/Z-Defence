using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public int health = 50;

    Animator anim;

    int deathType;

     CapsuleCollider capsuleCollider;

     float sinkSpeed = 2.5f;


    void Awake()
    {
        anim = GetComponent <Animator> ();
        capsuleCollider = GetComponent <CapsuleCollider> ();
    }

    public void TakeDamage(int damageTaken, Vector3 hitPoint)
    {

        health -= damageTaken;

        if(IsDead())
        {
            deathType = Random.Range(0, 1);

            if(deathType == 1)
            {
                anim.SetTrigger("Dead1");
            }
            else
            {
                anim.SetTrigger("Dead2");
            }

            RoundManager.zombiesInRound--;
            PointsManager.points += 10;
        }
    
    }

    private void SetKinematics(bool isKinematic)
    {
        capsuleCollider.isTrigger = isKinematic;
        capsuleCollider.attachedRigidbody.isKinematic = isKinematic;
    }

    public int CurrentHealth()
    {
        return health;
    }

    public bool IsDead()
    {
        
        return (health <= 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsDead())
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
            if (transform.position.y < -10f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
