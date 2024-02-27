using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    private Transform t;
    private SpriteRenderer spriteRenderer;
    public float health = 100f;
    private float speed = 1f;
    private float attackRange = 1.0f;
    private float cyclopsDamage = 10f;
    private float forceAmount = 100f;
    // sprite renderer of cyclops
    public SpriteRenderer spriteRender;

    // Accesses Atlas and its sprite renderer
    private Atlas_Level5 atlas;
    private SpriteRenderer atlasSpriteRenderer;

    /// Transform from the Atlas object used to find the player's position
    private Transform atlasTransform;

    private Rigidbody2D atlasRb;

    /// Vector from cyclops to the Atlas
    private UnityEngine.Vector2 OffsetToPlayer => atlasTransform.position - transform.position;

    /// Unit vector in the direction of the Atlas, relative to cyclops
    private UnityEngine.Vector2 HeadingToPlayer => OffsetToPlayer.normalized;
    // Time for cyclop's constant attack
    private float currentTime;
    private float tick;
    // Checks if Atlas is Hit
    public bool isAtlasHitRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        atlas = FindObjectOfType<Atlas_Level5>();
        atlasTransform = atlas.transform;
        atlasRb = atlas.GetComponent<Rigidbody2D>();
        // Gets the sprite renderer from Unity
        spriteRender = GetComponent<SpriteRenderer>();
        health = 100;
        atlasSpriteRenderer = atlas.GetComponent<SpriteRenderer>();


        // Lock rotation in the Z-axis to prevent flipping
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        speed = Random.Range(0.5f, 1.5f) * 1.25f;
        float size = 3f * 1.25f / speed;
        t.localScale = new Vector3(size, size, 0);



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
        currentTime = Time.time;
        tick = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        flip();
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

    //// Coroutine to introduce a delay before attacking
    //IEnumerator HitDelay()
    //{
    //    yield return new WaitForSeconds(1.0f);
    //    if (IsPlayerInRange())
    //    {
    //        hit();
    //    }
    //}
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

            //Atlas_Level5.health -= cyclopsDamage;
            Lvl5UI.AtlasChangeHealth(cyclopsDamage);
            atlasSpriteRenderer.color = Color.red;
            //Debug.Log("here-1");
            StartCoroutine(atlasHit());
        }
    }
    // Coroutine to handle the invulnerability duration
    private IEnumerator atlasHit()
    {
        if (isAtlasHitRunning) yield break; // Exit if already running
        isAtlasHitRunning = true;

        yield return new WaitForSeconds(0.2f); // Atlas is invulnerable for 1 second
        atlasSpriteRenderer.color = Color.white; // Reset color or remove this if color change is handled elsewhere

        isAtlasHitRunning = false; // Reset flag
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (isAtlasHitRunning)
        {
            return; // Exit if already running
        }
        rb.velocity = Vector2.zero;
        // Check if collided with Atlas
        if (collision.gameObject == atlas.gameObject && (Time.time > currentTime + tick))
        {
            // Hit the player
            hit();
            currentTime = Time.time;
        }
    }



    // checks if cyclops is dead
    private void checkIfDead()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            atlasSpriteRenderer.color = Color.white;
        }
    }

    // Sets orientation of sprite
    void flip()
    {
        if (OffsetToPlayer.x < 0f)
        {
            spriteRender.flipX = true;
        }
        else if (OffsetToPlayer.x > 0f)
        {
            spriteRender.flipX = false;
        }
    }

}
