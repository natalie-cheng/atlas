using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasLvl2 : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public static float health = 100;
    public static float maxHealth = 100;
    public static float xPos;
    private float rotationSpeed = 50f;
    private float speed = 2.25f;

    // call start
    private void Start()
    {
        // initialize atlas vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        xPos = transform.position.x;
    }

    // frame update
    private void Update()
    {
        Move();
        xPos = transform.position.x;
    }

    // move and update sprite
    private void Move()
    {
        // horizontal and vertical input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // set the direction, increase by speed
        Vector2 vec = new Vector2(horizontal, vertical);
        vec = vec.normalized;
        rb.velocity = vec * speed;

        // rotate towards direction of velocity
        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }

}
