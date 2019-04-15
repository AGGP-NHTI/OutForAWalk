using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth2 : MonoBehaviour
{
    public DamageEventInfo dam;

    public void Update()
    {
        if (dam.takingDamage)
        {
            if (dam.p2Damage)
            {
                dam.PlayerTwoDamage(dam.theDamage);
                Debug.Log(gameObject.name + " is " + dam.DamageType.verb + " by " + dam.type);
                Debug.Log(gameObject.name + "'s current HP: " + gameObject.GetComponent<PlayerPawn>().currentHealth);
            }
            else
            {
                dam.p2Damage = false;
            }
        }
    }
}
