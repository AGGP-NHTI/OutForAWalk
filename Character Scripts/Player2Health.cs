using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Health : PlayerHealth
{
    void Start()
    {
        currentHealth = maxHealth;
    }
}
