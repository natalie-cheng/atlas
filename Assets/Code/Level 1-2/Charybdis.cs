using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charybdis : MonoBehaviour
{
    public float gravityConstant = 60f; // gravity constant
    public float mass = 10f; // charybdis mass
    public GameObject atlasBoat;
    public float dmg = 10f;

    // physics update
    private void FixedUpdate()
    {
        ApplyGravity();
    }

    // apply gravity to the boat
    private void ApplyGravity()
    {
        Rigidbody2D boatrb = atlasBoat.GetComponent<Rigidbody2D>();

        // get the direction and distance to the boat
        Vector3 direction = boatrb.transform.position - transform.position;
        float distance = direction.magnitude;

        // calculate gravity force
        float force = (gravityConstant * mass * boatrb.mass) / (distance * distance);

        // apply gravity force to boat
        boatrb.AddForce(-direction.normalized * force);
    }

    // if it collides with anything
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy object
        if (collision.collider.name.Contains("Boat2"))
        {
            Lvl2UI.changeHealth(dmg);
        }
    }
}
