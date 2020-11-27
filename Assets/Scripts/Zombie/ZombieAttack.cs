using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
     public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    ZombieHealth zHealth;
    bool playerInRange;
    float timer;

    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        zHealth = GetComponent<ZombieHealth>();
        anim = GetComponent <Animator> ();
    }
    void OnCollisionEnter (Collision other)
    {
        // if player enters collider the zombie can attack
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    void OnCollisionExit (Collision other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update ()
    {   
        if(!PauseManager.Paused)
        {
            timer += Time.deltaTime;

            // if it meets these conditions then zombie can attack
            if(timer >= timeBetweenAttacks && playerInRange && zHealth.CurrentHealth() > 0)
            {
                Attack ();
            }
        }
        
    }

    void Attack ()
    {
        // reset
        timer = 0f;

        // if player isn't dead
        if(playerHealth.currentHealth > 0)
        {
            anim.SetTrigger("Attack");
            playerHealth.TakeDamage (attackDamage);
        }
    }
}
