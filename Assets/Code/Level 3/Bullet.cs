using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity;
    private Rigidbody2D rb;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 position = FindAnyObjectByType<Atlas_Level3>().transform.position;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        // set the velocity in the direction of the player
        // velocity is constant throughout shot life



        direction = direction - position;
        direction = direction.normalized;
        float x = direction.x;
        float y = direction.y;
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(x * 10f, y * 10f);
        // calculate the angle to the player
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle = angle - 45f;
        // rotate the shot by angle to face the player
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
