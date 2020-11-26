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
            if(!Controls)
            {
                Paused = !Paused;

                CursorVisible();
                
            }
        }
    }

    public static void CursorVisible()
    {
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
