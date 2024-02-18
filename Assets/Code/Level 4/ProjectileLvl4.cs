using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifespan = 10f;
    public float trackTime;
    private Collider2D myCollider;

    // Start is called before the first frame update
    void Start()
    {
        trackTime = 0;
    }

    private void Update()
    {
        trackTime += Time.deltaTime;

        if ( trackTime > lifespan)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if make contact with Boat, decrease boat health
        if (collision.collider.gameObject.GetComponent<Boat>())
        {
            collision.collider.gameObject.GetComponent<Boat>().GoLeft();
            print("Hit");
            Destroy(gameObject);
        } else if (!collision.collider.gameObject.GetComponent<Zeus>())
        {
            //Physics2D.IgnoreCollision(collision.collider, myCollider );
        }
    }
}
