using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    int health = 50;

    Animator anim;

    int deathType;


    void Awake()
    {
        anim = GetComponent <Animator> ();
    }

    public void TakeDamage(int damageTaken, Vector3 hitPoint)
    {
        if (!IsDead())
        {
            health -= damageTaken;
        }
        else
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
            
        }
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
            
        }
    }
}
