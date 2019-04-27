using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public bool isActive = false;
    public int whoCanPickup;
    string powerUpName;

    void Awake()
    {
        powerUpName = this.gameObject.name;

        if (!isActive)
        {
            whoCanPickup = 0;
        }

        if (whoCanPickup >= 4)
        {
            whoCanPickup = 0;
        }

        if (whoCanPickup <= 0)
        {
            whoCanPickup = 0;
        }

        switch (whoCanPickup)
        {
            case 0:
                GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("Nobody can pick up " + powerUpName);
                break;
            case 1:
                Debug.Log("Both should be able to pick up " + powerUpName);
                break;
            case 2:
                Debug.Log("Only the owner should be able to pick up " + powerUpName);
                break;
            case 3:
                Debug.Log("Only the pet should be able to pick up" + powerUpName);
                break;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (whoCanPickup == 1)
        {

            Destroy(gameObject);
        }

        if (whoCanPickup == 2)
        {
            if (col.gameObject.name == "Player1")
            {
                Destroy(gameObject);
            }

            if (col.gameObject.name == "Player2")
            {

            }
        }

        if (whoCanPickup == 3)
        {
            if (col.gameObject.name == "Player1")
            {

            }

            if (col.gameObject.name == "Player2")
            {
                Destroy(gameObject);
            }

        }
    }
}