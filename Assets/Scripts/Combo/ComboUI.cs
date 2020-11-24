using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboUI : MonoBehaviour
{
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(ComboManager.textActive)
        {
            text.enabled = true;
            text.text = "x" + ComboManager.comboMultiplier + " Combo";
        }
        else
        {
            text.enabled = false;
        }
    }
}
