using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    public static int roundNumber = 0;
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

    void Start()
    {
        Reset();
    }

    void Reset()
    {
        roundNumber = 0;
        roundStarted = false;
        PauseManager.Paused = false;
        PauseManager.Controls = false;
        GameOverManager.gameOvr = false;
        PointsManager.points = 0;
    }


    public void RoundStart()
    {
        cameraManager.SwitchToPlayer();
        gunDisplay.player = Instantiate(player, Vector3.up*15, Quaternion.identity);
        gunDisplay.SpawnWeapon();
        roundStarted = true;
        PauseManager.CursorVisible();
        roundText.text = "Round: " + ++roundNumber;
        CalculateDifficulty();
        zombiesInRound = numZombies;
        StartCoroutine(SpawnZombies());
    }

    void CalculateDifficulty()
    {
        numZombies += 2;
        if(roundNumber % 5 == 0) numZombies += 5;
    }

    IEnumerator SpawnZombies()
    {
        for (int i = 0; i < numZombies; i++)
        {
            while (PauseManager.Paused) { yield return null; }
            yield return new WaitForSeconds(1f);
            Instantiate(zombie, spawnPoints[i % 5].transform.position, Quaternion.identity);
        }
    }

    void EndRound()
    {
        roundStarted = false;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        cameraManager.SwitchToShop();
        shopUI.DisplayUI((int)ShopUIManager.CurrentScreen.Main);
        PauseManager.CursorVisible();
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
