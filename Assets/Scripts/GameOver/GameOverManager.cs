using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameOverManager : MonoBehaviour
{
    Canvas screen;

    public Text roundSurvived;

    static public UnityEvent gameOver = new UnityEvent();

    public static bool gameOvr = false;

    // Start is called before the first frame update
    void Start()
    {
        screen = GetComponent<Canvas> ();
        gameOver.AddListener(GameOver);
    }

    void GameOver()
    {
        screen.enabled = true;
        gameOvr = true;
        PauseManager.Paused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        roundSurvived.text = "You survived " + RoundManager.roundNumber + " rounds";
    }
}
