using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public float health = 100;
    private float speed = 1.0f;
    private float attackRange = 1.0f;
    private float cyclopsDamage = 50;
    private float forceAmount = 100f;

    // Accesses Atlas 
    private Atlas_Level5 atlas;

    /// Transform from the Atlas object used to find the player's position
    private Transform atlasTransform;

    private Rigidbody2D atlasRb;

    /// Vector from cyclops to the Atlas
    private UnityEngine.Vector2 OffsetToPlayer => atlasTransform.position - transform.position;

    /// Unit vector in the direction of the Atlas, relative to cyclops
    private UnityEngine.Vector2 HeadingToPlayer => OffsetToPlayer.normalized;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        atlas = FindObjectOfType<Atlas_Level5>();
        atlasTransform = atlas.transform;
        atlasRb = atlas.GetComponent<Rigidbody2D>();
        health = 100;

        // Lock rotation in the Z-axis to prevent flipping
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;


        //if (atlasRb != null)
        //{
        //    // Create a Vector2 representing the force to be applied
        //    Vector2 force = new Vector2(50f, 50f);

        //    // Add the force to the Rigidbody using AddForce method
        //    atlasRb.AddForce(force, ForceMode2D.Impulse);
        //}
        //else
        //{
        //    Debug.LogError("Rigidbody component not found!");
        //}
    }

    // Update is called once per frame
    void Update()
    {
        MoveAndHit();
        checkIfDead();
    }

    // Makes the cyclops move towards the player
    private void MoveAndHit()
    {
        // Accesses the cyclops's position
        float cyclopsXCoordinate = this.transform.position.x;
        float cyclopsYCoordinate = this.transform.position.y;
        UnityEngine.Vector2 cyclopsPosition = new UnityEngine.Vector2(cyclopsXCoordinate, cyclopsYCoordinate);

        // Accesses Atlas's position
        UnityEngine.Vector2 atlasPosition = new Vector2(atlasTransform.position.x, atlasTransform.position.y);

        // Makes the cyclops move towards the player
        UnityEngine.Vector3 directionToPlayer = new UnityEngine.Vector3(HeadingToPlayer.x, HeadingToPlayer.y, 0.0f);

        // Clamp the cyclops's position within the specified range
        cyclopsPosition.x = Mathf.Clamp(cyclopsPosition.x, -9.0f, 9.0f);
        cyclopsPosition.y = Mathf.Clamp(cyclopsPosition.y, -4.0f, 4.0f);

        // Apply the clamped position back to the GameObject's position
        rb.position = cyclopsPosition;

        //// Check if the player is in range
        //if (IsPlayerInRange())
        //{
        //    // Stop the cyclops
        //    rb.velocity = Vector2.zero;

        //    // Start the delay coroutine
        //    StartCoroutine(HitDelay());
        //}
        //else // If player is not in range
        //{
        //    // Move the cyclops
        //    rb.velocity = directionToPlayer * speed;
        //}
        rb.velocity = directionToPlayer * speed;
    }

    // Coroutine to introduce a delay before attacking
    IEnumerator HitDelay()
    {
        yield return new WaitForSeconds(1.5f);
        if (IsPlayerInRange())
        {
            hit();
        }
    }
    // Checks if Atlas is within attack range
    private bool IsPlayerInRange()
    {
        // Calculate the distance between Cyclops and Atlas
        float distanceToPlayer = Vector2.Distance(transform.position, atlasTransform.position);

        // Check if the player (Atlas) is within the attack range
        return distanceToPlayer <= attackRange;
    }

    private void hit()
    {
        if (atlasRb != null)
        {
            // Calculate the direction away from the collision point
            Vector2 pushDirection = (atlas.transform.position - transform.position).normalized;

            //Debug.Log(pushDirection * forceAmount);

            // Apply the force to push Atlas back
            atlasRb.AddForce(pushDirection * forceAmount, ForceMode2D.Impulse);

            Atlas_Level5.health -= cyclopsDamage;
            Debug.Log(pushDirection * forceAmount);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        // Check if collided with Atlas
        if (collision.gameObject == atlas.gameObject)
        {
            // Hit the player
            hit();
        }
    }



    // checks if cyclops is dead
    private void checkIfDead()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
