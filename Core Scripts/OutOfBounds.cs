using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : DamageEventInfo
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            takingDamage = true;

            if (other.gameObject.name == "Player1(Clone)")
            {
                p1Damage = true;
            }

            if (other.gameObject.name == "Player2(Clone)")
            {
                p2Damage = true;
            }
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player1(Clone)")
        {
            takingDamage = true;
            p1Damage = true;
        }

        if (other.gameObject.name == "Player2(Clone)")
        {
            takingDamage = true;
            p2Damage = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player1(Clone)")
        {
            takingDamage = false;
            p1Damage = false;
        }

        if (other.gameObject.name == "Player2(Clone)")
        {
            takingDamage = false;
            p2Damage = false;
        }
    }
}