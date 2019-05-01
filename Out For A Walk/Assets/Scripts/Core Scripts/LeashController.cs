using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeashController : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    public Game g;

    public float playerDistance;
    public float maxDistancePositive;
    public float maxDistanceNegative;

    void Update()
    {
        playerDistance = Vector2.Distance(g._player1Instance.transform.position, g._player2Instance.transform.position);

        if (playerDistance >= maxDistancePositive || playerDistance <= maxDistanceNegative)
        {
            if (g.PP1.isOwner)
            {
                g._player2Instance.transform.position = g._player1Instance.transform.position;
            }
            
            if (g.PP2.isOwner)
            {
                g._player1Instance.transform.position = g._player2Instance.transform.position;
            }
        }
    }
}