using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeashController : MonoBehaviour
{
    public Game g;

    public float playerDistance;
    public float maxDistancePositive;
    public float maxDistanceNegative;

    Vector2 relativePos;

    void Update()
    {
        playerDistance = Vector2.Distance(g._player1Instance.transform.position, g._player2Instance.transform.position);

        if (playerDistance >= maxDistancePositive || playerDistance <= maxDistanceNegative)
        {
            if (g.PP1.isRunning)
            {
                g._player2Instance.transform.position = Vector3.Lerp(g._player2Instance.transform.position, g._player1Instance.transform.position, Time.deltaTime);
            }
            else
            {
                g._player1Instance.transform.position = Vector3.Lerp(g._player1Instance.transform.position, g._player2Instance.transform.position, Time.deltaTime);
            }

            if (g.PP2.isRunning)
            {
                g._player1Instance.transform.position = Vector3.Lerp(g._player1Instance.transform.position, g._player2Instance.transform.position, Time.deltaTime);
            }
            else
            {
                g._player2Instance.transform.position = Vector3.Lerp(g._player2Instance.transform.position, g._player1Instance.transform.position, Time.deltaTime);
            }
        }
    }
}