using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aipatrol : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    public Transform[] movespot;
    private int random;

    void Start()
    {
        waitTime = startWaitTime;
        random = Random.Range(0, movespot.Length);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movespot[random].position, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position,movespot[random].position)<0.2f)
        {
            if(waitTime<=0)
            {
                random = Random.Range(0, movespot.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
