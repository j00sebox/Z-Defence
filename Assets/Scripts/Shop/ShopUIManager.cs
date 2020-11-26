using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUIManager : MonoBehaviour
{

    public GameObject[] otherUIs;

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
                    otherUIs[i].gameObject.SetActive(true);
                }
                else
                {
                    otherUIs[i].gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < otherUIs.Length; i++)
            {
                otherUIs[i].gameObject.SetActive(false);
            }
        }

        currentScreen = (CurrentScreen)index;
        
    }
}
