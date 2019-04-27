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
    public string TugInput;
    public bool isRunning;
    float dirX;
    float dirY;

    // Animations
    public BaseAnimator ba;
    Animator anim;
    SpriteRenderer sr;
    bool spriteNorth;
    bool spriteSouth;
    bool spriteWest;
    bool spriteEast;

    // Misc
    public bool isOwner;
    public bool isPet;

    public string direction = "South";

    public void Start()
    {
        if (this.gameObject.name == "Player1")
        {
            inputHorizontal = "Horizontal";
            inputVertical = "Vertical";
            inputRun = "Run";
            TugInput = "Pull";
        }

        if (this.gameObject.name == "Player2")
        {
            inputHorizontal = "Horizontal2";
            inputVertical = "Vertical2";
            inputRun = "Run2";
            TugInput = "Pull2";
        }

        anim = gameObject.GetComponent<Animator>();
        sr = gameObject.GetComponent<SpriteRenderer>();
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

        if (direction == "West" && !Input.GetButton(inputHorizontal))
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
            sr.sprite = ba.idleWest;
        }

        if (direction == "East" && !Input.GetButton(inputHorizontal))
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
            sr.sprite = ba.idleEast;
        }

        if (Input.GetButton(inputVertical))
        {
            Vertical(dirY);
        }

        if (direction == "North" && !Input.GetButton(inputVertical))
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
            sr.sprite = ba.idleNorth;
        }

        if (direction == "South" && !Input.GetButton(inputVertical))
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
            sr.sprite = ba.idleSouth;
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

        if (isOwner)
        {
            isPet = false;
            isOwner = true;
        }
        else
        {
            isOwner = false;
            isPet = true;
        }

        if (isPet)
        {
            isPet = true;
            isOwner = false;
        }
        else
        {
            isOwner = true;
            isPet = false;
        }


    }

    public override void Horizontal(float value)
    {
        if (value != 0)
        {
            if (dirX > 0)
            {
                sr.sprite = ba.moveEast;

                anim.SetBool("is_idle", false);
                anim.SetBool("is_moving", true);

                anim.SetBool("north", false);
                anim.SetBool("west", false);
                anim.SetBool("east", true);
                anim.SetBool("south", false);

                spriteNorth = false;
                spriteSouth = false;
                spriteWest = false;
                spriteEast = true;

                direction = "East";
            }

            if (dirX < 0)
            {
                sr.sprite = ba.moveWest;

                anim.SetBool("is_idle", false);
                anim.SetBool("is_moving", true);

                anim.SetBool("north", false);
                anim.SetBool("west", true);
                anim.SetBool("east", false);
                anim.SetBool("south", false);

                spriteNorth = false;
                spriteSouth = false;
                spriteWest = false;
                spriteEast = true;

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
        if (value != 0)
        {
            if (dirY > 0)
            {
                sr.sprite = ba.moveNorth;

                anim.SetBool("is_idle", false);
                anim.SetBool("is_moving", true);

                anim.SetBool("north", true);
                anim.SetBool("west", false);
                anim.SetBool("east", false);
                anim.SetBool("south", false);

                spriteNorth = true;
                spriteSouth = false;
                spriteWest = false;
                spriteEast = false;

                direction = "North";
            }

            if (dirY < 0)
            {
                sr.sprite = ba.moveSouth;

                anim.SetBool("is_idle", false);
                anim.SetBool("is_moving", true);

                anim.SetBool("north", false);
                anim.SetBool("west", false);
                anim.SetBool("east", false);
                anim.SetBool("south", true);

                spriteNorth = false;
                spriteSouth = true;
                spriteWest = false;
                spriteEast = false;

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
        sr.color = Color.red;
        sr.color = Color.white;

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
