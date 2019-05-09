using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    GameObject gameComponent;
    Game g;

    private void Start()
    {
        gameComponent = GameObject.Find("GameState");

        g = gameComponent.GetComponent<Game>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == g._player1Instance.name)
        {
            g._player1Instance.GetComponent<Player1Control>().TakeDamage(10);
        }

        if (col.gameObject.name == g._player2Instance.name)
        {
            g._player2Instance.GetComponent<Player2Control>().TakeDamage(10);
        }
    }
}
