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

    public float damage = 25f;

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
            PlayerPawn pp = other.GetComponentInParent<PlayerPawn>();
            EnemyPawn ep = other.GetComponentInParent<EnemyPawn>();
            if(pp)
            {
                Debug.Log("Hit Player");
                pp.TakeDamage(damage);
                Debug.Log(other.name);
                Destroy(gameObject);
            }
            else if(ep)
            {
                return;
            }
        }
    }
}
