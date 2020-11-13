using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainToArmoryButton : MonoBehaviour
{
    public ShopUIManager shopUI;

    Button armoryButton;

    // Start is called before the first frame update
    void Start()
    {
        armoryButton = GetComponent<Button> ();
        armoryButton.onClick.AddListener(ChangeScreen);
    }

    void ChangeScreen()
    {
        shopUI.DisplayUI((int)ShopUIManager.CurrentScreen.Armory);
    }
}
