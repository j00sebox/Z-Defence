using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFollow : MonoBehaviour
{
    GameObject player;

    public RaycastHit vision;

    Animator anim;

    float speed = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out vision))
        {
            anim.SetBool("IsRunning", true);
            transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed);
        }
    }
}
