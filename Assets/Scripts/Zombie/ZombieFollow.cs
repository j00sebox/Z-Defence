using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    GameObject player;

    public RaycastHit vision;

    Animator anim;

    float speed = 0.05f;

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
        if(!healthScript.IsDead())
        {
            targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);

            if(Physics.Raycast(transform.position + Vector3.up*17, transform.TransformDirection(Vector3.forward), out vision, 100f))
            {
                if(vision.collider.gameObject == player)
                {
                    anim.SetBool("IsRunning", true);
                    transform.position = Vector3.MoveTowards (transform.position, new Vector3(player.transform.position.x, 0f, player.transform.position.z) , speed);
                }
                else
                {
                    anim.SetBool("IsRunning", false);
                }
                
            }
            
        }
        
    }
}
