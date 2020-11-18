using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public int roundNumber = 0;
    public static bool roundStarted = false;

    public CameraManager cameraManager;

    public GameObject player;

    public GameObject zombie;

    public Text roundText;


    public GunDisplay gunDisplay;

    public GameObject spawnPoint;


    public void RoundStart()
    {
        cameraManager.SwitchToPlayer();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gunDisplay.player = Instantiate(player, Vector3.up*15, Quaternion.identity);
        Instantiate(zombie, spawnPoint.transform.position, Quaternion.identity);
        gunDisplay.SpawnWeapon();
        roundStarted = true;
        roundText.text = "Round: " + ++roundNumber;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
