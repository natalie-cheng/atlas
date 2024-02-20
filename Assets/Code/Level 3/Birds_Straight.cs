using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BirdManager : MonoBehaviour
{
    public float health = 10f;
    public GameObject atlas;
    public float speed = 1.5f;
    public float birdDmg = 25f;
    private Vector3 moveDirection;
    public Vector3 position;

    void Start()
    {

        position = gameObject.transform.position;
        CalculateMovement();


    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        MoveTowardsAtlas();
    }


    private void CalculateMovement()
    {
        if (atlas != null)
        {
            // Calculate direction from the bird to the atlas
            moveDirection = (atlas.transform.position - transform.position).normalized;
        }


    }
    void MoveTowardsAtlas()
    {
        // Move the bird in the initial calculated direction
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnBecameInvisible()
    {
        gameObject.transform.position = position;
        CalculateMovement();


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
