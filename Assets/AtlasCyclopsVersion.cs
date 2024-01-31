using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtlasCyclopsVersion : MonoBehaviour
{
    // vars
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float detectionRadius = 10f;
    private float forceAmount = 3f;
    private float facingThreshold = 0.9f;

    // Start is called before the first frame update
    void Start()
    {
        // initialize santa vars
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        check_if_hit();
    }

    public void check_if_hit()
    {
        if (Input.GetKeyDown("space"))
        {
            // Collect all instances of a cyclops
            Cyclops[] allCyclops = GameObject.FindObjectsOfType<Cyclops>();

            foreach (Cyclops cyclop in allCyclops)
            {
                if (IsObjectInHitRange(cyclop.transform))
                {
                    hit();

                }
            }
        }
    }

    private void hit()
    {
        Debug.Log("Hit");
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
            Vector3 directionToTarget = (otherTransform.position - transform.position).normalized;

            // Calculate the dot product of the forward direction of the current object and the direction to the target
            float dotProduct = Vector3.Dot(transform.forward, directionToTarget);

            // Check if the dot product is greater than the facing threshold
            if(dotProduct > facingThreshold)
            {
                return true;
            }
        }
        return false;

    }


}
