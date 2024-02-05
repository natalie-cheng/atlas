using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float orbLife;
    public float lifespan = 1000;
    // Start is called before the first frame update
    void Start()
    {
        orbLife = 0;
    }

    private void Update()
    {
        orbLife += 1;
        if ( orbLife > lifespan)
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
            collision.collider.gameObject.GetComponent<Boat>().MinusHealth();
            Destroy(gameObject);
            print("Hit");
        }
    }
}
