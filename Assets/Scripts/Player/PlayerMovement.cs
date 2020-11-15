using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x, z;

    public float speed = 12f;

    CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(RoundManager.roundStarted)
        {
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            cc.Move(move * speed * Time.deltaTime);
        }
    }
}
