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

    // when the game starts these static variables need to be reset
    void Reset()
    {
        roundNumber = 0;
        roundStarted = false;
        PauseManager.Paused = false;
        PauseManager.Controls = false;
        GameOverManager.gameOvr = false;
       // PointsManager.points = 0;
    }


    // start round sequence
    public void RoundStart()
    {
        cameraManager.SwitchToPlayer(); // change to first person view
        gunDisplay.player = Instantiate(player, Vector3.up*15, Quaternion.identity); // create player in the scene
        gunDisplay.SpawnWeapon(); // create the weapon in the first loadout slot for the player to use
        roundStarted = true;
        PauseManager.CursorVisible(); // set the cursor accordingly
        roundText.text = "Round: " + ++roundNumber; // increment and display round number
        CalculateDifficulty(); // increases the amount of zombies depending on the rpund number
        zombiesInRound = numZombies; // total number of the zombies that will be in the round
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
            // used to stop spawning zombies when the game is paused
            while (PauseManager.Paused) { yield return null; }
            // wait 1 second before spwaning another zombie
            yield return new WaitForSeconds(1f);
            // creates zombie at 1 of the 5 possible spawn points
            Instantiate(zombie, spawnPoints[i % 5].transform.position, Quaternion.identity);
        }
    }

    void EndRound()
    {
        roundStarted = false;
        Destroy(GameObject.FindGameObjectWithTag("Player")); // destroy player object
        cameraManager.SwitchToShop(); // switch back to top down view
        shopUI.DisplayUI((int)ShopUIManager.CurrentScreen.Main); // set the UI screen as the main shop screen
        PauseManager.CursorVisible();
    }

    // Update is called once per frame
    void Update()
    {
        // when no more zombies are left the round can end
        if(zombiesInRound == 0 && roundStarted)
        {
            EndRound();
        }
    }
}
