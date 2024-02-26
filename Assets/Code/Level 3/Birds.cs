using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    public float health = 10f;
    public float speed = 0.5f; // Speed of the movement
    private float time = 0f; // Time parameter for the figure-eight calculation
    public float birdDmg = 25f;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        float initialYPosition = transform.position.y; 
        transform.position = new Vector3(CalculateX(time) - 5f, CalculateY(time) + initialYPosition, transform.position.z); 
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Die();
        }
        else if (health == 5f)
        {
            spriteRenderer.color = Color.red;
        }

        // Update time
        time += Time.deltaTime * speed;

        // Calculate new position
        transform.position = new Vector3(CalculateX(time), CalculateY(time) + transform.position.y, transform.position.z);
    }

    private float CalculateX(float t)
    {
        return Mathf.Sin(t) * 10; // Scale and speed adjustment for X-axis
    }

    private float CalculateY(float t)
    {
        return Mathf.Sin(t) * Mathf.Cos(t) * 0.01f; // Creates the figure-eight pattern
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Atlas_Level3 atlas = FindObjectOfType<Atlas_Level3>();
        if (atlas != null && !atlas.isInvulnerable)
        {

            if (collision.gameObject.name == atlas.name)
            {
                atlas.TakeDamage(birdDmg);
            }
            else
            {
                health -= 5f;
            }
        }

    }

    private void Die()
    {
        Lvl3UI.numBirds--;
        Destroy(gameObject);
    }
}
