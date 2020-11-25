using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GiveUp : MonoBehaviour
{
    Button giveUp;

    // Start is called before the first frame update
    void Start()
    {
        giveUp = GetComponent<Button> ();
        giveUp.onClick.AddListener(GiveUpGame);
    }

    void GiveUpGame()
    {
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }
}
