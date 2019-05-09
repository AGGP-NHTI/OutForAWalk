using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : BasePawn
{
    // Health / Stamina
    public const float maxHealth = 100f;
    public const float maxStamina = 100f;

    public float currentHealth = maxHealth;
    public float currentStamina = maxStamina;

    public RectTransform HealthBar;
    public RectTransform staminaBar;

    // Movement
    public float move_speed = 1f;
    public float base_move = 1f;

    // Animations
    public Animator anim;
    public RuntimeAnimatorController ownerAnimations;
    public RuntimeAnimatorController petAnimations;

    // Misc
    float attackTimer = 0;
    float attackCD = 0.3f;

    public Collider2D attackTriggerNorth;
    public Collider2D attackTriggerSouth;
    public Collider2D attackTriggerEast;
    public Collider2D attackTriggerWest;

    public bool isOwner;
    public bool isPet;

    public string direction = "South";

    public void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        attackTriggerNorth.enabled = false;
        attackTriggerSouth.enabled = false;
        attackTriggerEast.enabled = false;
        attackTriggerWest.enabled = false;
    }

    public void FixedUpdate()
    {
        HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);
        staminaBar.sizeDelta = new Vector2(currentStamina, staminaBar.sizeDelta.y);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            base_move = 0;
            checkDeath();
            Debug.Log("You are dead.");
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
        anim.SetBool("is_dead", true);
    }

    public virtual void Attack(float distance, float direction, Vector3 dir)
    {
       
    }
}
