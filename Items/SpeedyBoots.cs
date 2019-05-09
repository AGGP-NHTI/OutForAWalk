using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedyBoots : Item
{
    public float newSpeed;
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
                PP1.base_move *= newSpeed;
            }

            if (col.gameObject == playerInstance2)
            {
                PP2.base_move *= newSpeed;
            }

            Debug.Log("Colliding " + col.gameObject.name);
            Destroy(gameObject);
        }

        if (whoCanPickup == 2)
        {
            if (col.gameObject == playerInstance1)
            {
                PP1.base_move *= newSpeed;
                Destroy(gameObject);
            }

        }

        if (whoCanPickup == 3)
        {
            if (col.gameObject == playerInstance2)
            {
                PP2.base_move *= newSpeed;
                Destroy(gameObject);
            }
        }
    }
}
