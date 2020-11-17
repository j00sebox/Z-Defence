using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static bool roundStarted = false;

    public CameraManager cameraManager;

    public GameObject player;

    public GameObject zombie;


    public GunDisplay gunDisplay;

    public GameObject spawnPoint;


    public void RoundStart()
    {
        cameraManager.SwitchToPlayer();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gunDisplay.player = Instantiate(player, Vector3.up, Quaternion.identity);
        Instantiate(zombie, spawnPoint.transform.position, Quaternion.identity);
        gunDisplay.SpawnWeapon();
        roundStarted = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
