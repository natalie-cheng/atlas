using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasLvl1 : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AudioSource sfx;
    private float speed = 2.5f;

    public static bool woodSfx;

    // call start
    private void Start()
    {
        // initialize atlas vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sfx = GetComponent<AudioSource>();

        woodSfx = false;
    }

    // frame update
    private void Update()
    {
        if (rb.velocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (rb.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        Move();
        if (woodSfx)
        {
            sfx.Play();
            woodSfx = false;
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
        vec = vec.normalized;
        rb.velocity = vec * speed;

        // update animation
        if (vec.magnitude > 0)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

}
