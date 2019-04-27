using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendLeash : Item
{
    public LeashController l;

    public override void OnTriggerEnter2D(Collider2D col)
    {
        if (whoCanPickup == 1)
        {
            if (col.gameObject.name == "Player1")
            {
                l.maxDistanceNegative++;
                l.maxDistancePositive--;

                if (l.maxDistancePositive <= 0)
                {
                    l.maxDistancePositive = 1;
                    l.maxDistanceNegative = -1;
                }

                Destroy(gameObject);
            }


            if (col.gameObject.name == "Player2")
            {
                l.maxDistanceNegative--;
                l.maxDistancePositive++;

                Destroy(gameObject);
            }
        }

        if (whoCanPickup == 2)
        {
            whoCanPickup = 1;
        }

        if (whoCanPickup == 3)
        {
            whoCanPickup = 1;
        }
    }

}
