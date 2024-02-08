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
    private float cyclopsDamage = 1;
    private float forceAmount = 30f;

    // Accesses Atlas 
    private Atlas atlas;

    /// Transform from the Atlas object used to find the player's position
    private Transform atlasTransform;

    /// Vector from cyclops to the Atlas
    private UnityEngine.Vector2 OffsetToPlayer => atlasTransform.position - transform.position;

    /// Unit vector in the direction of the Atlas, relative to cyclops
    private UnityEngine.Vector2 HeadingToPlayer => OffsetToPlayer.normalized;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        atlas = FindObjectOfType<Atlas>();
        atlasTransform = atlas.transform;
        health = 100;
        Atlas.health = 100;

        // Lock rotation in the Z-axis to prevent flipping
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
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

        // Check if the player is in range
        if (IsPlayerInRange())
        {
            // Stop the cyclops
            rb.velocity = Vector2.zero;

            // Start the delay coroutine
            StartCoroutine(HitDelay());
        }
        else // If player is not in range
        {
            // Move the cyclops
            rb.velocity = directionToPlayer * speed;
        }
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
        // Assuming your Atlas class has a Rigidbody2D component
        Rigidbody2D atlasRB = atlas.GetComponent<Rigidbody2D>();
        if (atlasRB != null)
        {
            // Calculate the direction away from the collision point
            Vector3 pushDirection = atlas.transform.position - transform.position;
            pushDirection.Normalize();

            // Apply the force to push Atlas back
            atlasRB.AddForce(pushDirection * forceAmount, ForceMode2D.Impulse);
            Atlas.health = Atlas.health - cyclopsDamage;
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
