using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atlas_Level5 : MonoBehaviour
{
    // vars
    public static Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float speed = 3.5f;
    private float detectionRadius = 1.75f;
    //private float forceAmount = 10000f;
    private float facingThreshold = 0.3f;
    private float lastHitTime = 0f;
    private float hitCooldown = 0.25f;
    private float swordDamage = 100;
    public static float health = 100;   
    public static float maxHealth = 100;
    // Animator reference
    public Animator animator;
    //private int swingAnimationDuration = 1;
    public bool isSwinging = false;
    public bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        // initialize santa vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Lock rotation in the Z-axis to prevent flipping
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        flip();
        Move();
        check_if_hit();
        HandleInput();
    }

    private void Move()
    {
        // horizontal and vertical input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // set the direction, increase by speed
        Vector2 vec = new Vector2(horizontal, vertical);
        if(rb != null)
        {
            rb.velocity = vec * speed;
        }
        animator.SetBool("walking", true);
    }


    //// For delay in hit
    //void FixedUpdate()
    //{
    //    check_if_hit();
    //}

    public void check_if_hit()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Collect all instances of a cyclops
            Cyclops[] allCyclops = GameObject.FindObjectsOfType<Cyclops>();
            foreach (Cyclops cyclop in allCyclops)
            {
                // Check if the cyclops is within hit range and Atlas is facing it
                if (IsObjectInHitRange(cyclop.transform))
                {
                    // Check if enough time has passed since the last hit
                    if (Time.time - lastHitTime >= hitCooldown)
                    {
                        hit(cyclop);
                        lastHitTime = Time.time; // Update the last hit time
                        //Debug.Log("here");
                    }
                }
            }
        }
    }



    private void hit(Cyclops cyclop)
    {
        // Assuming Cyclops has a Rigidbody2D component
        Rigidbody2D cyclopsRb = cyclop.GetComponent<Rigidbody2D>();
        SpriteRenderer cyclopssprite = cyclop.GetComponent<SpriteRenderer>();
        if (cyclopsRb != null)
        {
            //// Calculate the direction away from the collision point
            //Vector3 pushDirection = cyclop.transform.position - transform.position;
            //pushDirection.Normalize();

            //// Apply the force to push the Cyclops back
            //cyclopsRb.AddForce(pushDirection * forceAmount, ForceMode2D.Impulse);
            cyclop.health -= swordDamage;
            //cyclopssprite.color = Color.red;
            //StartCoroutine(cyclopsHit(cyclopssprite));
        }
    }

    //// Coroutine to handle the invulnerability duration
    //private IEnumerator cyclopsHit(SpriteRenderer cyclopssprite)
    //{
    //    yield return new WaitForSeconds(0.2f); // Atlas is invulnerable for 1 second
    //    cyclopssprite.color = Color.white; // Reset color or remove this if color change is handled elsewhere
    //}

    //// Checks if object is in hit range and Atlas is facing Cyclops
    //private bool IsObjectInHitRange(Transform otherTransform)
    //{
    //    // Calculate the distance between the current object and the target object
    //    float distance = Vector3.Distance(transform.position, otherTransform.position);
    //    // Check if the distance is less than the proximity threshold
    //    if (distance < detectionRadius)
    //    {
    //        // Calculate the direction from the current object to the target object
    //        //Vector3 directionToTarget = (otherTransform.position - transform.position).normalized;

    //        //// horizontal and vertical input axes
    //        //float horizontal = Input.GetAxis("Horizontal");
    //        //float vertical = Input.GetAxis("Vertical");
    //        //Vector3 movement = new Vector3(horizontal, vertical, 0.0f);


    //        //// Calculate the dot product of the forward direction of the current object and the direction to the target
    //        //float dotProduct = Vector3.Dot(movement, directionToTarget);

    //        //// Check if the dot product is greater than the facing threshold
    //        //if (dotProduct > facingThreshold)
    //        //{
    //        //    return true;
    //        //}
    //        return true;
    //    }
    //    return false;
    //}


    // Checks if object is in hit range and Atlas is facing Cyclops
    private bool IsObjectInHitRange(Transform otherTransform)
    {
        // Calculate the distance between the current object and the target object
        float distance = Vector3.Distance(transform.position, otherTransform.position);
        // Check if the distance is less than the proximity threshold
        if (distance < detectionRadius)
        {
           //Calculate the direction from the current object to the target object
           Vector3 directionToTarget = (otherTransform.position - transform.position).normalized;

            //// horizontal and vertical input axes
            //float horizontal = Input.GetAxis("Horizontal");
            //float vertical = Input.GetAxis("Vertical");
            //Vector3 movement = new Vector3(horizontal, vertical, 0.0f);


            //// Calculate the dot product of the forward direction of the current object and the direction to the target
            //float dotProduct = Vector3.Dot(movement, directionToTarget);

            // Calculate the direction the character is facing based on SpriteRenderer's flipX state
            Vector3 facingDirection = spriteRenderer.flipX ? Vector3.right : Vector3.left;

            // Calculate the dot product of the facing direction of the current object and the direction to the target
            float dotProduct = Vector3.Dot(facingDirection, directionToTarget);

            // Check if the dot product is greater than the facing threshold
            if (dotProduct > facingThreshold)
            {
                return true;
            }
            //return true;
        }
        return false;
    }

    // Sets orientation of sprite
    void flip()
    {
        if (isSwinging)
        {
            return;
        }

        // Gets horizontal and vertical inputs
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (horizontalInput < 0f)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput > 0f)
        {
            spriteRenderer.flipX = true;
        }
    }

    //private void animate()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space) && !isSwinging)
    //    {
    //        StartCoroutine(SwingSword());
    //    }

    //    // Check for user input to set animation parameters
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    if (horizontalInput != 0 || verticalInput != 0)
    //    {
    //        StartCoroutine(Walk());
    //    }

    //    animator.SetBool("walking", (horizontalInput != 0 || verticalInput != 0));
    //}

    //IEnumerator SwingSword()
    //{
    //    Cyclops[] allCyclops = GameObject.FindObjectsOfType<Cyclops>();
    //    foreach (Cyclops cyclop in allCyclops)
    //    {
    //        if(cyclop.isAtlasHitRunning)
    //        {
    //            yield break; // Exit if already running
    //        }
    //    }
    //    //Debug.Log("SwingSword coroutine started");
    //    isSwinging = true;
    //    animator.SetBool("swinging", true);

    //    // Adjust this value according to the duration of your swing animation
    //    yield return new WaitForSeconds(0.000001f); // Change 0.5f to match your animation's duration

    //    //Debug.Log("Swing animation complete");
    //    animator.SetBool("swinging", false);
    //    isSwinging = false;
    //}


    //IEnumerator Walk()
    //{
    //    Cyclops[] allCyclops = GameObject.FindObjectsOfType<Cyclops>();
    //    foreach (Cyclops cyclop in allCyclops)
    //    {
    //        if (cyclop.isAtlasHitRunning)
    //        {
    //            yield break; // Exit if already running
    //        }
    //    }
    //    isWalking = true;
    //    animator.SetBool("walking", true);

    //    for(int i = 0; i < 1000; i++){
    //        yield return new WaitForSeconds(0.0001f);
    //        if (Input.GetKeyDown(KeyCode.Space))
    //        {
    //            animator.SetBool("walking", false);
    //            StartCoroutine(SwingSword());
    //            yield break;
    //        }
    //    }
    //    //Debug.Log("Swing animation complete");
    //    animator.SetBool("walking", false);
    //    isWalking = false;
    //}

    // checks if Atlas is dead
    //public bool checkIfDead()
    //{
    //    if (health <= 0)
    //    {

    //        return true;

    //    }
    //    return false;
    //}

    //public void Dead()
    //{
    //    Destroy(this);
    //}

    // This method should be called from Update to handle input every frame
    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isSwinging)
        {
            isSwinging = true;
            StartCoroutine(SwingSword());
        }

        // Check for user input to set animation parameters
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool isMoving = horizontalInput != 0 || verticalInput != 0;

        // Start Walk coroutine only if not already walking and there is movement input
        if (isMoving && !isWalking)
        {
            StartCoroutine(Walk());
        }

        // Set walking animation parameter
        animator.SetBool("walking", isMoving);
    }

    private IEnumerator SwingSword()
    {
        isSwinging = true;
        animator.SetBool("swinging", true);

        // Wait for the duration of your swing animation
        // Adjust this value according to the duration of your swing animation
        yield return new WaitForSeconds(0.06f); // Example: 0.06 second for swing animation

        animator.SetBool("swinging", false);
        isSwinging = false;
    }

    private IEnumerator Walk()
    {
        isWalking = true;

        while (isWalking)
        {
            animator.SetBool("walking", true);

            // This loop now runs as long as the character is moving
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            isWalking = horizontalInput != 0 || verticalInput != 0;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("came here");
                // Exit if swinging starts
                animator.SetBool("walking", false);
                yield break;
            }

            // A small delay to allow for input checking each frame
            yield return null;
        }

        animator.SetBool("walking", false);
    }

}
