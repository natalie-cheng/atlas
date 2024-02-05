using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atlas_Level3 : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float health = 100;
    public float speed = 2;
    public GameObject bullet;
    public GameObject arrow;

    // call start
    private void Start()
    {
        // initialize santa vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // frame update
    private void Update()
    {
        Move();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        

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

    private void Shoot()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = diff.normalized;
        Instantiate(bullet, rb.position + direction, Quaternion.identity);
    }

}
