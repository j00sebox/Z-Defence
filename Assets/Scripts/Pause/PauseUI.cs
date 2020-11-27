using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    Canvas pauseMenu;

    void Start()
    {
        pauseMenu = GetComponent<Canvas> ();
    }

    // Update is called once per frame
    void Update()
    {
        // enable pause menu when it meets these conditions
        pauseMenu.enabled = ( PauseManager.Paused && !PauseManager.Controls && !GameOverManager.gameOvr );
    }
}
