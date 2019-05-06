using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class range : MonoBehaviour
{

    private Enemy parent;

    private void Start()
    {
        parent = GetComponent<Enemy>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
        {
            parent.Target1 = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            parent.Target1 = null;
        }
    }

}
