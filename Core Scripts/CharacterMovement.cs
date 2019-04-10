using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    /*********************************************************
    * This is the generic movement script for the character(s).
    **********************************************************/

    // Public Variables
    public float playerStamina = 100f;

    // Movement
    public float move_speed = 1f;
    public bool isRunning;
    public string inputHorizontal;
    public string inputVertical;
    public string runButton;
    public RectTransform staminaBar;

    void Start()
    {
        Debug.Log("Character is working.");
    }

    void Update()
    {
        if (Input.GetButton(runButton))
        {
            isRunning = true;

            if (playerStamina >= 1f)
            {
                move_speed += 0.25f;

                if (isRunning && Input.GetButton(inputHorizontal) || Input.GetButton(inputVertical))
                {
                    playerStamina -= 1;
                }
            }
            else
            {
                isRunning = false;
            }
        }
        else
        {
            isRunning = false;
        }

        if (playerStamina <= 99f && !isRunning)
        {
            playerStamina += 1f;
        }

        if (!isRunning)
        {
            move_speed = 1;
        }

        if (Input.GetButton(inputHorizontal))
        {
            horizontalMovement();
        }

        if (Input.GetButton(inputVertical))
        {
            verticalMovement();
        }

        staminaBar.sizeDelta = new Vector2(playerStamina, staminaBar.sizeDelta.y);

    }

    void horizontalMovement()
    {
        float dirX = Input.GetAxis(inputHorizontal) * move_speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);
    }

    void verticalMovement()
    {
        float dirX = Input.GetAxis(inputVertical) * move_speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, transform.position.y + dirX);
    }
}
