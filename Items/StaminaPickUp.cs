using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaPickUp : Item
{
    public float StaminaAmount;
    public Game g;

    private PlayerPawn PP1;
    private PlayerPawn PP2;

    private GameObject playerInstance1;
    private GameObject playerInstance2;


    public void Start()
    {
        playerInstance1 = g._player1Instance;
        playerInstance2 = g._player2Instance;

        PP1 = playerInstance1.GetComponent<PlayerPawn>();
        PP2 = playerInstance1.GetComponent<PlayerPawn>();

        Debug.Log(playerInstance1);
        Debug.Log(playerInstance2);

    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (whoCanPickup == 1)
        {
            if (col.gameObject == playerInstance1)
            {
                PP1.currentStamina *= StaminaAmount;
            }

            if (col.gameObject == playerInstance2)
            {
                PP2.currentStamina *= StaminaAmount;
            }

            Debug.Log("Colliding " + col.gameObject.name);
            Destroy(gameObject);
        }

        if (whoCanPickup == 2)
        {
            if (col.gameObject == playerInstance1)
            {
                PP1.currentStamina *= StaminaAmount;
                Debug.Log("Colliding " + col.gameObject.name);
                Destroy(gameObject);
            }

        }

        if (whoCanPickup == 3)
        {
            if (col.gameObject == playerInstance2)
            {
                PP2.currentStamina *= StaminaAmount;
                Debug.Log("Colliding " + col.gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
