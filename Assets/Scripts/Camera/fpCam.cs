using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpCam : MonoBehaviour
{

    float MouseX, MouseY;

    float sensitivity = 100f;

    public Transform playerBody;

    float xRot = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(RoundManager.roundStarted)
        {
            MouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            MouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRot -= MouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            playerBody.Rotate(Vector3.up * MouseX);
        }
    }
}
