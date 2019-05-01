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
    public string inputHorizontal;
    public string inputVertical;
    public string inputRun;
    public string attack;
    public bool isRunning;
    float dirX;
    float dirY;

    // Animations
    Animator anim;
    public RuntimeAnimatorController ownerAnimations;
    public RuntimeAnimatorController petAnimations;

    // Misc
    public bool isOwner;
    public bool isPet;

    string direction = "South";

    public void Start()
    {
        if (this.gameObject.name == "Player1")
        {
            inputHorizontal = "Horizontal";
            inputVertical = "Vertical";
            inputRun = "RunButton";
            attack = "Fire1";
        }

        if (this.gameObject.name == "Player2")
        {
            inputHorizontal = "Horizontal2";
            inputVertical = "Vertical2";
            inputRun = "RunButton2";
            attack = "Fire2";
        }

        anim = gameObject.GetComponent<Animator>();
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

        if (Input.GetAxis(inputHorizontal) != 0)
        {
            if (Input.GetAxis(inputVertical) == 0)
            {
                Horizontal(dirX);
            }
        }

        if (direction == "West" && Input.GetAxis(inputHorizontal) == 0)
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
        }

        if (direction == "East" && Input.GetAxis(inputHorizontal) == 0)
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
        }

        if (Input.GetAxis(inputVertical) != 0)
        {
            if (Input.GetAxis(inputHorizontal) == 0)
            {
                Vertical(dirY);
            }
        }

        if (Input.GetButton(attack))
        {
            Debug.Log("Button is being pressed.");
        }

        if (direction == "North" && Input.GetAxis(inputVertical) == 0)
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
        }

        if (direction == "South" && Input.GetAxis(inputVertical) == 0)
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
        }

        if (Input.GetButton(inputRun))
        {
            isRunning = true;
        }
        
        if (!Input.GetButton(inputRun))
        {
            isRunning = false;
        }

        if (!isRunning)
        {
            move_speed = base_move;
        }

        if (currentStamina <= 99f && !isRunning)
        {
            currentStamina += 1f;
        }

        if (isOwner)
        {
            isPet = false;
            isOwner = true;

            gameObject.GetComponent<Animator>().runtimeAnimatorController = ownerAnimations;
        }
        else
        {
            isOwner = false;
            isPet = true;

            gameObject.GetComponent<Animator>().runtimeAnimatorController = petAnimations;
        }

        if (isPet)
        {
            isPet = true;
            isOwner = false;

            gameObject.GetComponent<Animator>().runtimeAnimatorController = petAnimations;
        }
        else
        {
            isOwner = true;
            isPet = false;

            gameObject.GetComponent<Animator>().runtimeAnimatorController = ownerAnimations;
        }
    }

    public override void Horizontal(float value)
    {
        if (value != 0 && Input.GetAxis(inputVertical) == 0)
        {
            if (dirX > 0)
            {
                anim.SetBool("is_idle", false);
                anim.SetBool("is_moving", true);

                anim.SetBool("north", false);
                anim.SetBool("west", false);
                anim.SetBool("east", true);
                anim.SetBool("south", false);

                direction = "East";
            }

            if (dirX < 0)
            {
                anim.SetBool("is_idle", false);
                anim.SetBool("is_moving", true);

                anim.SetBool("north", false);
                anim.SetBool("west", true);
                anim.SetBool("east", false);
                anim.SetBool("south", false);

                direction = "West";
            }

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
        if (value != 0 && Input.GetAxis(inputHorizontal) == 0)
        {
            if (dirY > 0)
            {
                anim.SetBool("is_idle", false);
                anim.SetBool("is_moving", true);

                anim.SetBool("north", true);
                anim.SetBool("west", false);
                anim.SetBool("east", false);
                anim.SetBool("south", false);

                direction = "North";
            }

            if (dirY < 0)
            {
                anim.SetBool("is_idle", false);
                anim.SetBool("is_moving", true);

                anim.SetBool("north", false);
                anim.SetBool("west", false);
                anim.SetBool("east", false);
                anim.SetBool("south", true);

                direction = "South";
            }

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
        Destroy(gameObject);
    }
}
