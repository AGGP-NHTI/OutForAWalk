using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth1 : MonoBehaviour
{
    public DamageEventInfo dam;
    public Game g;

    public void Update()
    {
        Debug.Log(g._player1Instance);

        if (dam.takingDamage)
        {
            if (dam.p1Damage)
            {
                dam.PlayerOneDamage(dam.theDamage);
                Debug.Log(g._player1Instance.name + " is " + dam.DamageType.verb + " by " + dam.type);
                Debug.Log(g._player1Instance.name + "'s current HP: " + g._player1Instance.GetComponent<PlayerPawn>().currentHealth);
            }
            else
            {
                dam.p1Damage = false;
            }
        }
    }
}
