using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    GameObject player;

    public RaycastHit vision;

    Animator anim;

    float speed = 0.2f; // running speed

    float walkingSpeed = 0.1f;

    ZombieHealth healthScript;

    Vector3 targetPosition;

    Rigidbody rb;

    int mask;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        mask = LayerMask.GetMask("Player");

        anim = GetComponent<Animator> ();

        healthScript = GetComponent<ZombieHealth> ();

        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        // if player isn't dead
        if(!healthScript.IsDead() && !PauseManager.Paused)
        {
            // look at player
            targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);


            // look for player, if in line of sight chase after them, else walk
            if(Physics.Raycast(transform.position + Vector3.up*15, transform.TransformDirection(Vector3.forward), out vision, 1000f))
            {
                if(vision.collider.gameObject == player)
                {
                    anim.SetBool("IsWalking", false);
                    anim.SetBool("IsRunning", true);
                    transform.position = Vector3.MoveTowards (transform.position, new Vector3(player.transform.position.x, 0f, player.transform.position.z) , speed);
                }
                else
                {
                    Meander();
                }
                
            }
            else
            {
                Meander();
            }

            
            
        }
        
    }

    void Meander()
    {
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsWalking", true);
        transform.position = Vector3.MoveTowards (transform.position, new Vector3(player.transform.position.x, 0f, player.transform.position.z) , walkingSpeed);
    }
}
