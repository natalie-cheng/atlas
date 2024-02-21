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

    // call start
    private void Start()
    {
        // initialize atlas vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastShotTime = -reloadTime; 
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
            Shoot();
            lastShotTime = Time.time; 
        }





    }

    public void TakeDamage(float damage)
    {
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            Lvl3UI.changeHealth(damage); // Assuming this method reduces Atlas's health
            spriteRenderer.color = Color.red;
            StartCoroutine(InvulnerabilityTimer());
        }
    }

    // Coroutine to handle the invulnerability duration
    private IEnumerator InvulnerabilityTimer()
    {
        yield return new WaitForSeconds(1f); // Atlas is invulnerable for 1 second
        isInvulnerable = false;
        spriteRenderer.color = Color.blue; // Reset color or remove this if color change is handled elsewhere
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
        rb.velocity = vec * speed;
    }

    private void Shoot()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = gameObject.transform.position;
        diff = diff - position;
        Vector2 direction = diff.normalized;
        Instantiate(bullet, rb.position + direction, Quaternion.identity);
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
