using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atlas : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public static float health = 100;
    public float speed = 2;

    // call start
    private void Start()
    {
        // initialize santa vars
        health = 100;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // frame update
    private void Update()
    {
        Move();

    }

    // move and update sprite
    private void Move()
    {
        // horizontal and vertical input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // set the direction, increase by speed
        Vector2 vec = new Vector2(horizontal, vertical); ;
        rb.velocity = vec * speed;
    }
}
