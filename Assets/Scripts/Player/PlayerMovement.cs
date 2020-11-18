using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float x, z;

    public float speed = 12f;

    public float maxStamina = 100f;

    float currentStamina;

    float newStamina;

    CharacterController cc;

    RectTransform staminabar;

    public float staminaRegen = 11f;

    int sprintMultiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController> ();

        staminabar = GameObject.FindGameObjectWithTag("StaminaBar").GetComponent<RectTransform> ();

        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if(RoundManager.roundStarted)
        {

            if (Input.GetKey(KeyCode.LeftShift) && currentStamina >= 0)
            {
                Sprint();
                sprintMultiplier = 3;
            }
            else if (currentStamina < maxStamina)
            {
                StamniaRegen();
                sprintMultiplier = 1;
            }

            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            cc.Move(move * speed * sprintMultiplier * Time.deltaTime);
        }
    }

    void Sprint()
    {
        currentStamina -= 10 * Time.deltaTime;
        UpdateStamBar();
    }

    void StamniaRegen()
    {
        currentStamina += staminaRegen * Time.deltaTime;
        UpdateStamBar();
    }

    void UpdateStamBar()
    {
        newStamina = ( (currentStamina / maxStamina ) * 200f);
        staminabar.sizeDelta = new Vector2(newStamina, staminabar.sizeDelta.y);
    }
}
