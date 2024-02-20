using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charybdis : MonoBehaviour
{
    public float gravityConstant = 60f; // gravity constant
    public float mass; // charybdis mass
    private GameObject atlasBoat;
    public float dmg;
    private float currentTime;
    private float tick;
    private bool withinRange;
    private float distance;

    private void Start()
    {
        atlasBoat = GameObject.FindWithTag("BoatLvl2");
        currentTime = Time.time;
        tick = 1f;
        withinRange = false;
        distance = 0;
    }

    // physics update
    private void FixedUpdate()
    {
        ApplyGravity();
    }

    private void Update()
    {
        if (withinRange && (Time.time>currentTime+tick))
        {
            Lvl2UI.changeHealth(dmg);
            currentTime = Time.time;
        }
    }

    // apply gravity to the boat
    private void ApplyGravity()
    {
        Rigidbody2D boatrb = atlasBoat.GetComponent<Rigidbody2D>();
        Vector3 direction = boatrb.transform.position - transform.position;
        if (!withinRange)
        {
            // get the distance
            distance = direction.magnitude;
        }

        // calculate gravity force
        float force = (gravityConstant * mass * boatrb.mass) / (distance * distance);

        // apply gravity force to boat
        boatrb.AddForce(-direction.normalized * force);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("BoatLvl2"))
        {
            withinRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        // Reset the flag when the other object exits
        if (collider.CompareTag("BoatLvl2"))
        {
            withinRange = false;
        }
    }
}
