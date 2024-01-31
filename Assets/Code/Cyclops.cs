using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private static float health = 100;
    private float speed = 1.5f;

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
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    // Makes the cyclops move towards the player
    private void Move()
    {
        // Accesses the cyclops's position
        float cyclopsXCoordinate = this.transform.position.x;
        float cyclopsYCoordinate = this.transform.position.y;
        UnityEngine.Vector2 cyclopsPosition = new UnityEngine.Vector2(cyclopsXCoordinate, cyclopsYCoordinate);

        // Accesses Atlas's position
        UnityEngine.Vector2 atlasPosition = new Vector2(atlasTransform.position.x, atlasTransform.position.y);

        //// Calculate the distance between the cyclops and Atlas
        //float distanceToPlayer = Vector2.Distance(cyclopsPosition, atlasPosition);

        // Makes the cyclops move towards the player
        UnityEngine.Vector3 directionToPlayer = new UnityEngine.Vector3(HeadingToPlayer.x, HeadingToPlayer.y, 0.0f);

        // Clamp the cyclops's position within the specified range
        cyclopsPosition.x = Mathf.Clamp(cyclopsPosition.x, -9.0f, 9.0f);
        cyclopsPosition.y = Mathf.Clamp(cyclopsPosition.y, -4.0f, 4.0f);

        // Apply the clamped position back to the GameObject's position
        rb.position = cyclopsPosition;

        // Sets new Enemy's velocity
        rb.velocity = directionToPlayer * speed;
    }

}
