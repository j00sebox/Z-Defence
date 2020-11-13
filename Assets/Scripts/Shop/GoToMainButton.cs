using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoToMainButton : MonoBehaviour
{
    public ShopUIManager shopUI;

    Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        backButton = GetComponent<Button> ();
        backButton.onClick.AddListener(ChangeScreen);
    }

    void ChangeScreen()
    {
        shopUI.DisplayUI((int)ShopUIManager.CurrentScreen.Main);
    }
}
