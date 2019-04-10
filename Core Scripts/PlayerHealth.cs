using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public const float maxHealth = 100;
    public float currentHealth = maxHealth;
    public RectTransform HealthBar;

    // string mainMenuScene = "MainMenu";

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            gameObject.SetActive(false);
            Debug.Log("You are dead.");
        }

        HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);
    }
}
