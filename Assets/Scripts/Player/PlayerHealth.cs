using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100;

    public float currentHealth;

    float newHealth;

    public bool godMode = false;

    bool damaged;
    bool isDead;

    Image damageImage;

    RectTransform healthbar;

    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    public float flashSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        damageImage = GameObject.FindGameObjectWithTag("DamageImage").GetComponent<Image> ();

        healthbar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<RectTransform> ();

        UpdateHealthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseManager.Paused)
        {
            // screen flashed red if player was damaged
            if (damaged)
            {
                damageImage.color = flashColour;
            }
            // otherwise the screen goes back to clear
            else
            {
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }

            // reset the damaged flag
            damaged = false;
        }
        
    }

    public void TakeDamage(int amount)
    {
        if (godMode)
            return;

        if(!isDead)
        {
            damaged = true;

            // reduce the current health by the damage amount
            currentHealth -= amount;

            UpdateHealthBar();

            // if player is dead
            if (currentHealth <= 0)
            {
                Death();
            }
        }
        
    }

    void Death()
    {
        isDead = true;
        // invoke the game over event
        GameOverManager.gameOver.Invoke();
    }

    void UpdateHealthBar()
    {
        // need to convert health to percentage of health bar width
        if (currentHealth <= 0)
        {
            healthbar.sizeDelta = new Vector2(0, healthbar.sizeDelta.y);
        }
        else
        {
            newHealth = ( (currentHealth / maxHealth) * 200f );
            healthbar.sizeDelta = new Vector2( newHealth, healthbar.sizeDelta.y);
        }
    }
}
