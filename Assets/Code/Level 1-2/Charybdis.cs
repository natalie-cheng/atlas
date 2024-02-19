using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charybdis : MonoBehaviour
{
    public float gravityConstant = 60f; // gravity constant
    public float mass; // charybdis mass
    private GameObject atlasBoat;
    public float dmg;
    public float radius;
    private float currentTime;
    private float tick;

    private void Start()
    {
        atlasBoat = GameObject.FindWithTag("BoatLvl2");
        currentTime = Time.time;
        tick = 0.5f;
    }

    // physics update
    private void FixedUpdate()
    {
        ApplyGravity();
    }

    private void Update()
    {
        if (WithinRange() && (Time.time>currentTime+tick))
        {
            Lvl2UI.changeHealth(dmg);
            currentTime += tick;
        }
    }

    // apply gravity to the boat
    private void ApplyGravity()
    {
        Rigidbody2D boatrb = atlasBoat.GetComponent<Rigidbody2D>();
        Vector3 direction = boatrb.transform.position - transform.position;
        float distance = radius;
        if (!WithinRange())
        {
            // get the distance
            distance = direction.magnitude;
        }

        // calculate gravity force
        float force = (gravityConstant * mass * boatrb.mass) / (distance * distance);

        // apply gravity force to boat
        boatrb.AddForce(-direction.normalized * force);
    }

    private bool WithinRange()
    {
        Rigidbody2D boatrb = atlasBoat.GetComponent<Rigidbody2D>();
        float distanceTo = Vector2.Distance(boatrb.transform.position, transform.position);
        if (distanceTo < radius) return true;
        else return false;
    }
}
