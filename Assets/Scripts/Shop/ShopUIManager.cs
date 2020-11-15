using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{

    Canvas[] otherUIs;

    public enum CurrentScreen
    {
        Main,
        Build,
        Armory,

        Loadout,

        None
        
    };

    public CurrentScreen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentScreen = CurrentScreen.Main;
        otherUIs = GetComponentsInChildren<Canvas> ();

        DisplayUI((int)currentScreen);
    }

    public void DisplayUI(int index)
    {
        if((CurrentScreen)index != CurrentScreen.None)
        {
            for (int i = 0; i < otherUIs.Length; i++)
            {
                if (i == index)
                {
                    otherUIs[i].enabled = true;
                }
                else
                {
                    otherUIs[i].enabled = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < otherUIs.Length; i++)
            {
                otherUIs[i].enabled = false;
            }
        }

        currentScreen = (CurrentScreen)index;
        
    }
}
