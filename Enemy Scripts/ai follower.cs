using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aifollower : MonoBehaviour
{
    public float speed;
    public float SDistance;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("player").GetComponent<Transform>();

    }

    void Update()
    {
        if(Vector2.Distance(transform.position, target.position)>SDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
