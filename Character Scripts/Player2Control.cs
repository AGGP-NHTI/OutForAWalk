using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Control : PlayerPawn
{
    float dirX;
    float dirY;

    public string inputHorizontal;
    public string inputVertical;
    public string inputRun;
    public string attack;

    void Awake()
    {
        inputHorizontal = "Horizontal2";
        inputVertical = "Vertical2";
        attack = "Fire2";
        inputRun = "RunButton2";
    }

    public bool isRunning;

    void Update()
    {
        if (Input.GetAxis(inputHorizontal) != 0)
        {
            Horizontal(dirX);
        }

        if (Input.GetAxis(inputVertical) != 0)
        {
            Vertical(dirY);
        }

        if (direction == "West" && Input.GetAxis(inputHorizontal) == 0 && !Input.GetButton(attack))
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
        }

        if (direction == "East" && Input.GetAxis(inputHorizontal) == 0 && !Input.GetButton(attack))
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
        }

        if (direction == "North" && Input.GetAxis(inputVertical) == 0 && !Input.GetButton(attack))
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
        }

        if (direction == "South" && Input.GetAxis(inputVertical) == 0 && !Input.GetButton(attack))
        {
            anim.SetBool("is_idle", true);
            anim.SetBool("is_moving", false);
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

        if (Input.GetButton(attack))
        {
            Fire1(true);
        }

        if (!Input.GetButton(attack))
        {
            Fire1(false);
        }

        if (currentStamina <= 99f && !isRunning)
        {
            currentStamina += 1f;
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

        dirY = Input.GetAxis(inputVertical) * move_speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + dirY);
    }

    public override void Fire1(bool value)
    {
        if (value)
        {
            anim.SetBool("is_attacking", true);
            anim.SetBool("is_idle", false);

            if (direction == "North")
            {
                attackTriggerNorth.enabled = true;
            }

            if (direction == "South")
            {
                attackTriggerSouth.enabled = true;
            }

            if (direction == "East")
            {
                attackTriggerEast.enabled = true;
            }

            if (direction == "West")
            {
                attackTriggerWest.enabled = true;
            }
        }
        else
        {
            anim.SetBool("is_attacking", false);

            attackTriggerNorth.enabled = false;
            attackTriggerSouth.enabled = false;
            attackTriggerEast.enabled = false;
            attackTriggerWest.enabled = false;
        }
    }

    public override void runButton(bool value)
    {
        if (value)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }
}