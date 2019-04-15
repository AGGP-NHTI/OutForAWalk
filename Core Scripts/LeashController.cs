using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeashController : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    public float playerDistance;
    public float maxDistancePositive;
    public float maxDistanceNegative;

    void Update()
    {
        playerDistance = Vector2.Distance(playerOne.transform.position, playerTwo.transform.position);


        if (playerDistance >= maxDistancePositive || playerDistance <= maxDistanceNegative)
        {
            Debug.Log(playerDistance);

            playerTwo.transform.position = playerOne.transform.position;
        }
    }
}