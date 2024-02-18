using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    public float health = 10f;
    public float speed = 0.5f; // Speed of the movement
    private float time = 0f; // Time parameter for the figure-eight calculation
    private float birdDmg = 25f;

    // Start is called before the first frame update
    void Start()
    {
        // Optionally, adjust the starting position based on the desired offset and pattern
        float initialYPosition = transform.position.y; // Keep the original Y position as an offset
        transform.position = new Vector3(CalculateX(time) - 5f, CalculateY(time) + initialYPosition, transform.position.z); // Adjust -5f as needed
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Die();
        }

        // Update time
        time += Time.deltaTime * speed;

        // Calculate new position
        transform.position = new Vector3(CalculateX(time), CalculateY(time) + transform.position.y, transform.position.z);
    }

    private float CalculateX(float t)
    {
        // Adjust these parameters to fit the screen and movement preferences
        return Mathf.Sin(t) * 10; // Scale and speed adjustment for X-axis
    }

    private float CalculateY(float t)
    {
        return Mathf.Sin(t) * Mathf.Cos(t) * 0.01f; // Creates the figure-eight pattern
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Atlas_Level3 atlas = FindObjectOfType<Atlas_Level3>();
        if (atlas != null)
        {
            if (collision.gameObject.name == atlas.name)
            {
                Lvl3UI.changeHealth(birdDmg);
                atlas.spriteRenderer.color = Color.red;
            }
            else
            {
                health -= 5f;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Atlas_Level3 atlas = FindObjectOfType<Atlas_Level3>();
        atlas.spriteRenderer.color = Color.white;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private void Die()
    {
        Lvl3UI.numBirds--;
        Destroy(gameObject);
    }
}
