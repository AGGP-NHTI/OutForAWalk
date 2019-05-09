using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : EnemyActor
{
    public const float maxHealth = 100f;
    public float currentHealth = maxHealth;

    Animator anim;
    public RuntimeAnimatorController slimeAnims;

    string direction = "South";

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            checkDeath();
            Debug.Log(gameObject.name + " is dead.");
        }

    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public void checkDeath()
    {
        Destroy(gameObject);
    }
}
