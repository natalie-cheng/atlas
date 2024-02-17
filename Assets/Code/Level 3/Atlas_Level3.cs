using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Atlas_Level3 : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    public SpriteRenderer spriteRenderer;
    public float health = 100;
    public float speed = 4;
    public GameObject bullet;
    public GameObject arrow;
    private float lastShotTime;
    public float reloadTime = 3f;
    // call start
    private void Start()
    {
        // initialize santa vars
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
        if (Input.GetAxis("Attack") == 1f && Time.time - lastShotTime >= reloadTime)
        {
            Shoot();
            lastShotTime = Time.time; // Update lastShotTime to the current time
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
        Vector2 position = gameObject.transform.position;
        diff = diff - position;
        Vector2 direction = diff.normalized;
        Instantiate(bullet, rb.position + direction, Quaternion.identity);
    }

    private void die()
    {
        Destroy(gameObject);
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
