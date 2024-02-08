using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 velocity;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 position = FindAnyObjectByType<Atlas_Level3>().transform.position;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = direction - position;
        direction = direction.normalized;
        float x = direction.x;
        float y = direction.y;
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(x * 2f, y * 2f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
