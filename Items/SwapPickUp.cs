using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPickUp : Item
{
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
        PP2 = playerInstance2.GetComponent<PlayerPawn>();
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (whoCanPickup == 1)
        {
            if (PP1.isOwner)
            {
                // Player 1
                PP1.isOwner = false;

                // Player 2
                PP2.isOwner = true;
            }

            if (PP1.isPet)
            {
                // Player 1
                PP1.isOwner = true;

                // Player 2
                PP2.isOwner = false;
            }

            Debug.Log("Player 1 is Owner: " + PP1.isOwner);
            Debug.Log("Player 2 is Owner: " + PP2.isOwner);
            Debug.Log("Player 1 is Pet: " + PP1.isPet);
            Debug.Log("Player 2 is Pet: " + PP2.isPet);

            Destroy(gameObject);
        }

    }
}
