using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainToBuildButton : MonoBehaviour
{
    public ShopUIManager shopUI;

    Button buildButton;

    // Start is called before the first frame update
    void Start()
    {
        buildButton = GetComponent<Button> ();
        buildButton.onClick.AddListener(ChangeScreen);
    }

    void ChangeScreen()
    {
        shopUI.DisplayUI((int)ShopUIManager.CurrentScreen.Build);
    }
}
