using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atlas_Level5 : MonoBehaviour
{
    // vars
    public static Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float speed = 2;
    private float detectionRadius = 1.5f;
    //private float forceAmount = 10000f;
    //private float facingThreshold = 0.3f;
    private float lastHitTime = 0f;
    private float hitCooldown = 0.25f;
    private float swordDamage = 100;
    public static float health = 100;
    public static float maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        // initialize santa vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Lock rotation in the Z-axis to prevent flipping
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        check_if_hit();
    }

    private void Move()
    {
        // horizontal and vertical input axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // set the direction, increase by speed
        Vector2 vec = new Vector2(horizontal, vertical); ;
        rb.velocity = vec * speed;
    }


    // For delay in hit
    void FixedUpdate()
    {
        check_if_hit();
    }

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
        if (cyclopsRb != null)
        {
            //// Calculate the direction away from the collision point
            //Vector3 pushDirection = cyclop.transform.position - transform.position;
            //pushDirection.Normalize();

            //// Apply the force to push the Cyclops back
            //cyclopsRb.AddForce(pushDirection * forceAmount, ForceMode2D.Impulse);
            cyclop.health -= swordDamage;
            //Debug.Log(cyclop.health);
        }
    }

    // Checks if object is in hit range and Atlas is facing Cyclops
    private bool IsObjectInHitRange(Transform otherTransform)
    {
        // Calculate the distance between the current object and the target object
        float distance = Vector3.Distance(transform.position, otherTransform.position);
        // Check if the distance is less than the proximity threshold
        if (distance < detectionRadius)
        {
            // Calculate the direction from the current object to the target object
            //Vector3 directionToTarget = (otherTransform.position - transform.position).normalized;

            //// horizontal and vertical input axes
            //float horizontal = Input.GetAxis("Horizontal");
            //float vertical = Input.GetAxis("Vertical");
            //Vector3 movement = new Vector3(horizontal, vertical, 0.0f);


            //// Calculate the dot product of the forward direction of the current object and the direction to the target
            //float dotProduct = Vector3.Dot(movement, directionToTarget);

            //// Check if the dot product is greater than the facing threshold
            //if (dotProduct > facingThreshold)
            //{
            //    return true;
            //}
            return true;
        }
        return false;

    }

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

}
