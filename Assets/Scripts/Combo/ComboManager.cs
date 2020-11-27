using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    public static float comboMultiplier = 1f;

    public static bool zombieKilled = false;

    float comboAddition = 0.5f;

    public static bool comboActive = false;

    public static bool textActive = false;

    float timer;

    float comboTime = 2f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // if the combo time expires reset multiplier
        if(timer >= comboTime)
        {
            timer = 0f;
            comboActive = false;
            textActive = false;
            comboMultiplier = 1f;
        }


        // after a zombie dies the combo becomes active
        if(zombieKilled)
        {
            if(comboActive)
            {
                comboMultiplier += comboAddition;
                textActive = true;
            }

            // reset timer 
            timer = 0f;
            comboActive = true;
            zombieKilled = false; // another zombie needs to be killed in order to increase the multiplier
        }
    }
}
