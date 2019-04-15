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
    public string inputHorizontal;
    public string inputVertical;
    public string inputRun;
    public bool isRunning;
    float dirX;
    float dirY;

    public void Start()
    {
        if (this.gameObject.name == "Player1" || this.gameObject.name == "Player1(Clone)")
        {
            inputHorizontal = "Horizontal";
            inputVertical = "Vertical";
            inputRun = "Run";
        }

        if (this.gameObject.name == "Player2" || this.gameObject.name == "Player2(Clone)")
        {
            inputHorizontal = "Horizontal2";
            inputVertical = "Vertical2";
            inputRun = "Run2";
        }
    }

    public void Update()
    {
        HealthBar.sizeDelta = new Vector2(currentHealth, HealthBar.sizeDelta.y);
        staminaBar.sizeDelta = new Vector2(currentStamina, staminaBar.sizeDelta.y);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            checkDeath();
            Debug.Log("You are dead.");
        }

        if (Input.GetButton(inputHorizontal))
        {
            Horizontal(dirX);
        }

        if (Input.GetButton(inputVertical))
        {
            Vertical(dirY);
        }

        if (Input.GetButton(inputRun))
        {
            isRunning = true;
        }
        
        if (Input.GetButtonUp(inputRun))
        {
            isRunning = false;
        }

        if (!isRunning)
        {
            move_speed = 1;
        }

        if (currentStamina <= 99f && !isRunning)
        {
            currentStamina += 1f;
        }
    }

    public override void Horizontal(float value)
    {
        if (value != 0)
        {
            if (isRunning)
            {
                if (currentStamina >= 1f)
                {
                    move_speed += 0.25f;
                }
                else
                {
                    isRunning = false;
                }

                currentStamina -= 1;
            }
        }

        dirX = Input.GetAxis(inputHorizontal) * move_speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
    }

    public override void Vertical(float value)
    {
        if (value != 0)
        {
            if (isRunning)
            {
                if (currentStamina >= 1f)
                {
                    move_speed += 0.25f;
                }
                else
                {
                    isRunning = false;
                }

                currentStamina -= 1;
            }
        }

        dirY = Input.GetAxis(inputVertical) * move_speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + dirY);
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
        //_controller.RequestSpectate();
        Destroy(gameObject);
    }
}
