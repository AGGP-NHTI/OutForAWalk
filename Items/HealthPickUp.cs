using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : Item
{
    public float HealingAmount;
    public GameObject damMan;
    public Game g;

    private GameObject playerInstance1;
    private GameObject playerInstance2;

    private PlayerHealth1 PH1;
    private PlayerHealth2 PH2;


    public void Start()
    {
        playerInstance1 = g._player1Instance;
        playerInstance2 = g._player2Instance;

        PH1 = damMan.GetComponent<PlayerHealth1>();
        PH2 = damMan.GetComponent<PlayerHealth2>();

        Debug.Log(playerInstance1);
        Debug.Log(playerInstance2);

        Debug.Log(PH1);
        Debug.Log(PH2);
    }

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (whoCanPickup == 1)
        {
            if (col.gameObject == playerInstance1)
            {
                PH1.dam.PlayerOneDamage(-HealingAmount);
                Debug.Log("Healing should happen with an amount of " + HealingAmount);
            }

            if (col.gameObject == playerInstance2)
            {
                PH2.dam.PlayerTwoDamage(-HealingAmount);
                Debug.Log("Healing should happen with an amount of " + HealingAmount);
            }

            Debug.Log("Colliding " + col.gameObject.name);
            Destroy(gameObject);
        }

        if (whoCanPickup == 2)
        {
            if (col.gameObject == playerInstance1)
            {
                PH1.dam.PlayerOneDamage(-HealingAmount);
                Debug.Log("Healing should happen with an amount of " + HealingAmount);

                Debug.Log("Colliding " + col.gameObject.name);
                Destroy(gameObject);
            }
        }

        if (whoCanPickup == 3)
        {
            if (col.gameObject == playerInstance2)
            {
                PH2.dam.PlayerTwoDamage(-HealingAmount);
                Debug.Log("Healing should happen with an amount of " + HealingAmount);

                Debug.Log("Colliding " + col.gameObject.name);
                Destroy(gameObject);
            }
        }
    }
}
