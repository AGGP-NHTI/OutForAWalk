using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletScript : MonoBehaviour
{
    public Vector3 moveDir = Vector3.zero;
    public float moveSpeed = 20f;
    public float lifetime = 15f;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.velocity = moveSpeed * gameObject.transform.forward;
        Destroy(gameObject, lifetime);
    }

    public void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != gameObject.name)
        {
            Debug.Log(other.name);
            Destroy(gameObject);
        }
    }
}
