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

        if(timer >= comboTime)
        {
            timer = 0f;
            comboActive = false;
            textActive = false;
            comboMultiplier = 1f;
        }

        if(zombieKilled)
        {
            if(comboActive)
            {
                comboMultiplier += comboAddition;
                textActive = true;
            }

            timer = 0f;
            comboActive = true;
            zombieKilled = false;
        }
    }
}
