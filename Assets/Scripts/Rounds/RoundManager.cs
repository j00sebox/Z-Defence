using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static bool roundStarted = false;

    public CameraManager cameraManager;

    public GameObject player;

    public GunDisplay gunDisplay;


    public void RoundStart()
    {
        cameraManager.SwitchToPlayer();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Instantiate(player, Vector3.up*3, Quaternion.identity);
        gunDisplay.SpawnWeapon();
        roundStarted = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
