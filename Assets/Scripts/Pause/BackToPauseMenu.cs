using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToPauseMenu : MonoBehaviour
{
    Button backButton;

    public Canvas controlCanvas;

    public Canvas pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        backButton = GetComponent<Button> ();

        backButton.onClick.AddListener(GoBack);
    }

    void GoBack()
    {
        pauseCanvas.enabled = true;
        controlCanvas.enabled = false;
        PauseManager.Controls = false;
    }
}
