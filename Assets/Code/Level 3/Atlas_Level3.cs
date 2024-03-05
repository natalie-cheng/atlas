using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Atlas_Level3 : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public static float health = 100;
    public float speed = 7;
    public GameObject bullet;
    public GameObject arrow;
    private float lastShotTime;
    public float reloadTime = 1.5f;
    public static float maxHealth = 100;
    public bool isInvulnerable = false;
    private Animator animator;


    // call start
    private void Start()
    {
        // initialize atlas vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastShotTime = -reloadTime;
        animator = GetComponent<Animator>();
    }

    // frame update
    private void Update()
    {
        if (health <= 0)
        {
            die();
        }

        Move();
        if ((Input.GetAxis("Attack") == 1f || Input.GetKeyDown(KeyCode.Space)) && Time.time - lastShotTime >= reloadTime)
        {
            Audio_Manager audio = FindObjectOfType<Audio_Manager>();
            audio.bowSound();
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePos.x > transform.position.x && spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
            if (mousePos.x < transform.position.x && spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }

            StartCoroutine(shootArrow());
            lastShotTime = Time.time; 
        }
        flip();




    }

    private void Shoot()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = gameObject.transform.position;
        diff = diff - position;
        Vector2 direction = diff.normalized;
        Instantiate(bullet, rb.position + direction, Quaternion.identity);


    }

    private IEnumerator shootArrow()
    {
        animator.SetBool("isShooting", true);

        yield return new WaitForSeconds(0.2f);


        animator.SetBool("isShooting", false);
        Shoot(); // Now spawn the bullet after the animation has started
    }


    void flip()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            Lvl3UI.changeHealth(damage); 
            spriteRenderer.color = Color.red;
            StartCoroutine(InvulnerabilityTimer());
        }
    }


    private IEnumerator InvulnerabilityTimer()
    {
        yield return new WaitForSeconds(1f); 
        isInvulnerable = false;
        spriteRenderer.color = Color.white; 
    }

    // move and update sprite
    private void Move()
    {
        // horizontal and vertical input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // set the direction, increase by speed
        Vector2 vec = new Vector2(horizontal, vertical);
        if (vec.magnitude > 1)
        {
            vec.Normalize();
        }

        if (vec.x != 0 || vec.y != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        rb.velocity = vec * speed;
    }



    private void die()
    {
        //Destroy(gameObject);
        DestroyAllWithTag("Bird");
        DestroyAllWithTag("Bird_1");
    }

    void DestroyAllWithTag(string tag)
    {
        GameObject[] objectsToDestroy = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obj in objectsToDestroy)
        {
            Destroy(obj);
        }
    }


}
