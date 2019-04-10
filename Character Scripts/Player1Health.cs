using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Health : PlayerHealth
{
    void Start()
    {
        currentHealth = maxHealth;
    }
}
