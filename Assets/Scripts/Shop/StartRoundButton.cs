using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRoundButton : MonoBehaviour
{
   public ShopUIManager shopUI;

   public RoundManager rm;
   

    Button loadoutButton;

    // Start is called before the first frame update
    void Start()
    {
        loadoutButton = GetComponent<Button> ();
        loadoutButton.onClick.AddListener(ChangeScreen);
    }

    void ChangeScreen()
    {
        shopUI.DisplayUI((int)ShopUIManager.CurrentScreen.None);
        rm.RoundStart();
        
    }
}
