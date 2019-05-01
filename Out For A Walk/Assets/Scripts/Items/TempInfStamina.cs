using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempInfStamina : Item
{
    public float infinityCounter = 0;
    private float infinityTicker = 0;
    public Game g;

    private bool p1IsStamina = false;
    private bool p2IsStamina = false;

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
    }

    public void FixedUpdate()
    {
        if (p1IsStamina)
        {
            PP1.currentStamina++;

            if (PP1.currentStamina >= 101)
            {
                PP1.currentStamina = 100;
            }

            Debug.Log(infinityCounter);
        }

        if (p2IsStamina)
        {
            PP2.currentStamina++;

            if (PP2.currentStamina >= 101)
            {
                PP2.currentStamina = 100;
            }

            Debug.Log(infinityCounter);
        }

        infinityCounter -= infinityTicker;

        if (infinityCounter <= 0)
        {
            infinityCounter = 0;
            Destroy(gameObject);
        }
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (whoCanPickup == 1)
        {
            if (col.gameObject == playerInstance1)
            {
                p1IsStamina = true;
                infinityTicker = 0.01f;
                Debug.Log(infinityTicker);
            }

            if (col.gameObject == playerInstance2)
            {
                p2IsStamina = true;
                infinityTicker = 0.01f;
                Debug.Log(infinityTicker);
            }

            Debug.Log("Colliding " + col.gameObject.name);
            this.gameObject.GetComponent<SortingLayer>().value.Equals(-10);
        }

        if (whoCanPickup == 2)
        {
            if (col.gameObject == playerInstance1)
            {
                p1IsStamina = true;
                infinityTicker = 0.01f;
                Debug.Log(infinityTicker);
            }

        }

        if (whoCanPickup == 3)
        {
            if (col.gameObject == playerInstance2)
            {
                p2IsStamina = true;
                infinityTicker = 0.01f;
                Debug.Log(infinityTicker);
            }

        }
    }
}
