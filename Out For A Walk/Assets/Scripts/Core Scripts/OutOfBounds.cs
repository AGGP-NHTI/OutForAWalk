using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : DamageEventInfo
{
    public void Start()
    {
        _player1Instance = g._player1Instance;
        _player2Instance = g._player2Instance;
    }

    public void Update()
    {
        if (p1Damage)
        {
            PlayerOneDamage(theDamage);
        }

        if (p2Damage)
        {
            PlayerTwoDamage(theDamage);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Player1")
        {
            p1Damage = true;
            takingDamage = true;
        }

        if (other.gameObject.name == "Player2")
        {
            p2Damage = true;
            takingDamage = true;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            takingDamage = true;
            p1Damage = true;
        }

        if (other.gameObject.name == "Player2")
        {
            takingDamage = true;
            p2Damage = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player1")
        {
            takingDamage = false;
            p1Damage = false;
        }

        if (other.gameObject.name == "Player2")
        {
            takingDamage = false;
            p2Damage = false;
        }
    }
}