using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool Paused = false;

    public static bool Controls = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // if not on controls screen
            if(!Controls)
            {
                // switch paused status
                Paused = !Paused;

                // set cursor accordingly
                CursorVisible();
                
            }
        }
    }

    public static void CursorVisible()
    {
        // if paused or round not started then cursor should be visible
        bool vis = ( Paused || !RoundManager.roundStarted );

        Cursor.visible = vis;

        if(vis)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
