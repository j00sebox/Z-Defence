using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        continueButton = GetComponent<Button> ();

        continueButton.onClick.AddListener(UnPause);
    }

    void UnPause()
    {
        PauseManager.Paused = false;
        PauseManager.CursorVisible();
    }
}
