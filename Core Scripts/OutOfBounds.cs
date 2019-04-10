using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float theDamage;
    bool takingDamage = false;
    bool p1Damage = false;
    bool p2Damage = false;

    void Update()
    {
        if (takingDamage)
        {
            if (p1Damage)
            {
                player1.GetComponent<Player1Health>().TakeDamage(theDamage);
            }
            else
            {
                p1Damage = false;
            }

            if (p2Damage)
            {
                player2.GetComponent<Player2Health>().TakeDamage(theDamage);
            }
            else
            {
                p2Damage = false;
            }

            takingDamage = false;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            takingDamage = true;

            if (other.gameObject.name == "Player1")
            {
                p1Damage = true;
            }

            if (other.gameObject.name == "Player2")
            {
                p2Damage = true;
            }
        }
    }

}