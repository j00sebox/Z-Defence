using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;

    public int currentHealth;
    public bool godMode = false;

    bool damaged;
    bool isDead;

    Image damageImage;

    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public float flashSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        damageImage = GameObject.FindGameObjectWithTag("DamageImage").GetComponent<Image> ();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        if (godMode)
            return;

        // Set the damaged flag so the screen will flash.
        damaged = true;

        // Reduce the current health by the damage amount.
        currentHealth -= amount;

        // Set the health bar's value to the current health.
        //healthSlider.value = currentHealth;

        // Play the hurt sound effect.
        //playerAudio.Play();

        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // ... it should die.
            Death();
        }
    }

    void Death()
    {

    }
}
