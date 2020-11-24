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
        pauseMenu.enabled = ( PauseManager.Paused && !PauseManager.Controls );
    }
}
