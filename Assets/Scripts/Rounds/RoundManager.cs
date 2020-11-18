using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public int roundNumber = 0;
    public static bool roundStarted = false;

    public static int zombiesInRound;

    public List<GameObject> spawnPoints;

    public CameraManager cameraManager;

    public GameObject player;

    public GameObject zombie;

    public Text roundText;

    int numZombies = 5;

    public GunDisplay gunDisplay;

    public GameObject spawnPoint;

    public ShopUIManager shopUI;


    public void RoundStart()
    {
        cameraManager.SwitchToPlayer();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gunDisplay.player = Instantiate(player, Vector3.up*15, Quaternion.identity);
        gunDisplay.SpawnWeapon();
        roundStarted = true;
        roundText.text = "Round: " + ++roundNumber;
        CalculateDifficulty();
        zombiesInRound = numZombies;
        SpawnZombies();
    }

    void CalculateDifficulty()
    {
        numZombies += 2;
        if(roundNumber % 5 == 0) numZombies += 5;
    }

    void SpawnZombies()
    {
        for (int i = 0; i < numZombies; i++)
        {
            int rand = Random.Range(0, spawnPoints.Count - 1);
            Instantiate(zombie, spawnPoints[rand].transform.position, Quaternion.identity);
        }
    }

    void EndRound()
    {
        roundStarted = false;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        cameraManager.SwitchToShop();
        shopUI.DisplayUI((int)ShopUIManager.CurrentScreen.Main);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        if(zombiesInRound == 0 && roundStarted)
        {
            EndRound();
        }
    }
}
