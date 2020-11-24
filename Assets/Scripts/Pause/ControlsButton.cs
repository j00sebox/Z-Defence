using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsButton : MonoBehaviour
{
    Button controlsButton;

    public Canvas controlCanvas;

    public Canvas pauseCanvas;


    // Start is called before the first frame update
    void Start()
    {
        controlsButton = GetComponent<Button> ();

        controlsButton.onClick.AddListener(ControlsScreen);
    }

    void ControlsScreen()
    {
        pauseCanvas.enabled = false;
        PauseManager.Controls = true;
        controlCanvas.enabled = true;
    }
}
